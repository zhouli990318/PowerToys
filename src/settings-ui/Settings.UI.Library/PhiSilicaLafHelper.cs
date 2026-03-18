// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.PowerToys.Settings.UI.Library;

/// <summary>
/// Shared constants and helper for the Phi Silica Limited Access Feature (LAF) unlock.
/// </summary>
public static class PhiSilicaLafHelper
{
    public const string FeatureId = "com.microsoft.windows.ai.languagemodel";
    public const string Token = "TOKEN==";
    public const string Attestation = "8wekyb3d8bbwe has registered their use of com.microsoft.windows.ai.languagemodel with Microsoft and agrees to the terms of use.";

    private static bool _unlocked;

    /// <summary>
    /// Ensures the Phi Silica LAF token has been unlocked. Safe to call multiple times.
    /// </summary>
    public static void EnsureUnlocked()
    {
        if (_unlocked)
        {
            return;
        }

        var access = global::Windows.ApplicationModel.LimitedAccessFeatures.TryUnlockFeature(
            FeatureId,
            Token,
            Attestation);

        _unlocked = access.Status == global::Windows.ApplicationModel.LimitedAccessFeatureStatus.Available
            || access.Status == global::Windows.ApplicationModel.LimitedAccessFeatureStatus.AvailableWithoutToken;
    }
}
