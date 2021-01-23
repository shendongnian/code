    private void RetrieveKey()
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection globalSettingSection = (AppSettingsSection)config.GetSection("globalSettings");
                key = globalSettingSection.Settings["key"].Value;
            }
