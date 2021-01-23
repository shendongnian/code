    private void UpdateConfig(string key, string value)
    {
        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings[key].Value = value;
        config.Save(ConfigurationSaveMode.Modified, true);
        ConfigurationManager.RefreshSection("appSettings");
    }
