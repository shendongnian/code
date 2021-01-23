      public static void Register()
        {
            ConfigOptions options = new ConfigOptions();
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));
            config.EnableCors();.....
