        public static T GetSetting<T>(string settingName,
            string settingsFile = null, bool
            ignoreCase = true) where T : IConvertible
        {
            foreach (Setting setting in Settings)
            {
                if ((settingsFile == setting.File || settingsFile == null)
                    && (settingName == setting.Name
                       || (ignoreCase == true && (settingName.ToLower() == setting.Name.ToLower()))))
                {
                    return convertToType<T>(setting.Value);
                }
            }
            return default(T);
        }
    
        private static T convertToType<T>(IConvertible value) where T : IConvertible
        {
            return (T)value.ToType(typeof(T), null);
        }
        private object value1;
        public bool Value1AsBool = (bool)SettingsReader.GetSetting<bool>(nameof(value1));
        public String Value1AsString = (string)SettingsReader.GetSetting<string>(nameof(value1));
        private object value2;
        public double Value2AsDouble = (double)SettingsReader.GetSetting<double>(nameof(value2));
        public string Value2AsString = (string)SettingsReader.GetSetting<string>(nameof(value2));
        public int Value2AsInt32 = (int)SettingsReader.GetSetting<int>(nameof(value2));
