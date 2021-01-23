    public static class ConfigurationExtensions
    {
        public static T GetConfig<T>(this IConfiguration config) where T : new()
        {
            var settings = new T();
            config.Bind(settings);
            return settings;
        }
        public static T GetConfig<T>(this IConfiguration config, string section) where T : new()
        {
            var settings = new T();
            config.GetSection(section).Bind(settings);
            return settings;
        }
    }
