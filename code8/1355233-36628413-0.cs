     public void UpdateService(string FilePathOld, string FilePathNew)
            {
                string[] Keys = { "SleepTimeInSeconds", "LogCleanInMinutes", "LogFileSize", "SqlTrans", "RemoteType", "DebugMode", "SleepError", "LogLevel", "LogSqlClient", "LogFile", "DebugRemote" };
                Dictionary<string, string> Old = new Dictionary<string, string>();
                Dictionary<string, string> New = new Dictionary<string, string>();
    
                ExeConfigurationFileMap configOld = new ExeConfigurationFileMap();
                configOld.ExeConfigFilename = FilePathOld;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configOld, ConfigurationUserLevel.None);
    
                ExeConfigurationFileMap configNew = new ExeConfigurationFileMap();
                configNew.ExeConfigFilename = FilePathNew;
                Configuration config2 = ConfigurationManager.OpenMappedExeConfiguration(configNew, ConfigurationUserLevel.None);
    
                KeyValueConfigurationCollection settings = config.AppSettings.Settings;
                Old = settings.AllKeys.ToDictionary(key => key, key => settings[key].Value);
                KeyValueConfigurationCollection settings2 = config2.AppSettings.Settings;
                New = settings.AllKeys.ToDictionary(key => key, key => settings[key].Value);
    
                foreach (var NewKey in New)
                {
                    string value;
                    if (Old.TryGetValue(NewKey.Key, out value))
                    {
                        if (value != NewKey.Value)
                        {
                            foreach (string Key in Keys)
                            {
                                if (NewKey.Key == Key)
                                    Old[NewKey.Key] = NewKey.Value;
                            }
                        }
                    }
                    else
                    {
                        Old.Add(NewKey.Key, NewKey.Value);
                    }
                }
    
                foreach (var NewKey in Old)
                {
                    string key = NewKey.Key;
                    string value = NewKey.Value;
                    config.AppSettings.Settings[key].Value = value;
                }
                config.Save();
    
            }
