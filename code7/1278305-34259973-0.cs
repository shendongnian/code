        public static class MyConfigurationManager
        {
            public static string GetSetting(string name)
            {
                return CloudConfigurationManager.GetSetting(name);
            }
        }
