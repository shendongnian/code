    System.Configuration.ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = "C:\\mydemo\\web.config";
    
                System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                AppSettingsSection section = (AppSettingsSection)configuration.GetSection("appSettings");
                if (section.Settings.AllKeys.Any(key => key == "MYDATA"))
                {
                    section.Settings["MYDATA"].Value = updateConfigId;
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
