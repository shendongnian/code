    if (Settings.Default.UpgradeRequired)
    {
        Settings.Default.Upgrade();
        Settings.Default.UpgradeRequired = false;
        Settings.Default.Save();
    }
 
