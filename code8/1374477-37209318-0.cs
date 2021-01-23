    if (Properties.Settings.Default.SettingsUpgradeRequired)
    {
        try
        {
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.SettingsUpgradeRequired = false;
            Properties.Settings.Default.Save();
        }
        catch (...)
        {
           ... // Upgrade failed - tell the user or whatever
        }
    }
