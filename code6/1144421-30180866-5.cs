    public static void SaveSettings(SettingsList list)
    {
        Settings.Default.SettingsObjects = list.ToBase64();
        Settings.Default.Save();
    }
