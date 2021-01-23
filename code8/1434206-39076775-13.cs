        public IConfigurationRoot Configuration { get; set; }
        public Startup()
        {
           var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
           Configuration = builder.Build();
        } 
        public void ConfigureServices(IServiceCollection services)
        {
            var isFakeMode= Configuration["ServiceRegistrationMode"] == "Fake";
            if (isFakeMode)
            {
                // register other fake dependencies
                services.AddSingleton<ITasksRepository, TasksRepositoryFake>();
            }
            else
            {
                // register other real dependencies
                services.AddSingleton<ITasksRepository, TasksRepository>();
            }
        }
        
