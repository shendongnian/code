    if (Properties.Settings.Default.SettingsUpgradeRequired)
    {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.SettingsUpgradeRequired = false;
        Properties.Settings.Default.Save();
    }
