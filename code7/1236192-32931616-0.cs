                // Create app settings, based on dictionary settings from central database
                Dictionary<string, string> configSettings = null;
                using (var db = container.Resolve<IDbConnectionFactory>().Open())
                {
                    configSettings = db.Dictionary<string, string>(db.From<ConfigSetting>());
                }
                var dicSettings = new DictionarySettings(configSettings);
                AppSettings = dicSettings;
