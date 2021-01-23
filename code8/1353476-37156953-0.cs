    public void UpdateService(string FilePathOld, string FilePathNew, string LatestVersion)
    {
            Dictionary<string, string> Old = new Dictionary<string, string>();
            Dictionary<string, string> New = new Dictionary<string, string>();
            if (ExisteFicheiro(FilePathNew) == true && ExisteFicheiro(FilePathOld) == true)
            {
                ExeConfigurationFileMap configOld = new ExeConfigurationFileMap();
                configOld.ExeConfigFilename = FilePathOld;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configOld, ConfigurationUserLevel.None);
                ExeConfigurationFileMap configNew = new ExeConfigurationFileMap();
                configNew.ExeConfigFilename = FilePathNew;
                Configuration config2 = ConfigurationManager.OpenMappedExeConfiguration(configNew, ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = config.AppSettings.Settings;
                Old = settings.AllKeys.ToDictionary(key => key, key => settings[key].Value);
                KeyValueConfigurationCollection settings2 = config2.AppSettings.Settings;
                New = settings2.AllKeys.ToDictionary(key => key, key => settings2[key].Value);
                foreach (var NewKey in New)
                {
                    string value;
                    if (Old.TryGetValue(NewKey.Key, out value))
                    {
                        if (value != NewKey.Value)
                        {
                            //if (ExistsKey(NewKey.Key, false) == true)
                            Old[NewKey.Key] = NewKey.Value;
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
                    if (config.AppSettings.Settings[key] != null)
                    {
                        config.AppSettings.Settings[key].Value = value;
                        if (key == "Version")
                            config.AppSettings.Settings[key].Value = LatestVersion;
                    }
                    else
                    {
                        config.AppSettings.Settings.Add(key, value);
                    }
                    if (config.AppSettings.Settings["Version"] == null)
                    {
                        config.AppSettings.Settings.Add("Version", LatestVersion);
                    }
                }
                config.Save();
            }
            else
            {
                Erro NovoErro = new Erro();
                Global.Erro = "O ficheiro \"OrcaService.exe.config\" ou o ficheiro \"Orca.exe.config\" não existem nos caminhos especificados!";
            }
    }
