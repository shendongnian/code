    public static class AppSettingsExtensions
    {
        public static string Required(this NameValueCollection appSettings, string key)
        {
            var settingsValue = appSettings[key];
            if (string.IsNullOrEmpty(settingsValue))
                throw new MissingAppSettingException(key);
            return settingsValue;
        }
        public static string ValueOrDefault(this NameValueCollection appSettings, string key, string defaultValue)
        {
            return appSettings[key] ?? defaultValue;
        }
    }
    public class MissingAppSettingException : Exception
    {
        internal MissingAppSettingException(string key, Type expectedType)
            : base(string.Format(@"An expected appSettings value with key ""{0}"" and type {1} is missing.", key, expectedType.FullName))
        { }
        public MissingAppSettingException(string key)
            : base(string.Format(@"An expected appSettings value with key ""{0}"" is missing.", key))
        { }
    }
