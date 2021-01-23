        public static class MyConfigurationManager
        {
            public static string GetSetting(string name)
            {
                return ConfigurationManager.AppSettings.Get(name);
            }
        }
