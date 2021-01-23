       public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath).AddJsonFile("config.json");
            Configuration = builder.Build();
            var connStr = Configuration.Get("connString");
        }
