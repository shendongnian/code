    public class test
    {
        static IConfigurationSection _Settings;
        static test()
        {
            IConfiguration _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _Settings = _config.GetSection("AppSettings");
        }
        public static string GetAppVersion()
        {
            return _Settings["AppVersion"];
        }
    }
