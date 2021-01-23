     public static bool SetAppSettings<TType>(string key, TType value)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return false;
                Configuration appConfig = ConfigurationManager.OpenExeConfiguration(GetCurrentApplicationPath());
                AppSettingsSection appSettings = (AppSettingsSection)appConfig.GetSection("appSettings");
                if (appSettings.Settings[key] == null)
                    appSettings.Settings.Add(key, value.ToString());
                else
                    appSettings.Settings[key].Value = value.ToString();
                appConfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }
