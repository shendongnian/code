    {
        private static string _connectionString;
        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json");
                Configuration = builder.Build();
                _connectionString = Configuration.Get<string>("Data:MyDb:ConnectionString");
            }
            return _connectionString;
        }
        public static IConfigurationRoot Configuration { get; set; }
    }
