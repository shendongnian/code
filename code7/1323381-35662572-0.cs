    private static string ReadSettingString(string key)
    {
        try
        {
            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);
            var appSettings = MyAppConfig.AppSettings;
            string result = appSettings?.Settings?[key]?.Value ?? string.Empty;
            return result;
        }
        catch (ConfigurationErrorsException)
        {
            MessageBox.Show("Error reading app settings");
            return string.Empty;
        }
    }
