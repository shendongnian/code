    private void UpdateSetting(string key, string value)
    {
        var configuration = ConfigurationManager
           .OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    
        // Now we need to update the setting in memory as well
        UpdateSettingInMemory(key, value);
    }
    private void UpdateSettingInMemory(string key, string value)
    {
        var configuration = ConfigurationManager
            .OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
