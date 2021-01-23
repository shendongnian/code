    public static void UpdateAppSetting(string key, string value)
    {
        var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();
        ConfigurationManager.RefreshSection("appSettings");
    }
