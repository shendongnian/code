    private static void CheckUserSettingsUpgradeRequired()
    {
        if (Settings.Default.UserSettingsUpgradeRequired)
        {
            Settings.Default.Upgrade();
            Settings.Default.UserSettingsUpgradeRequired = false;
            Settings.Default.Save();
        }
    }
