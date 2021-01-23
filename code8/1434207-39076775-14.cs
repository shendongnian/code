        public IConfigurationRoot Configuration { get; set; }
        public IHostingEnvironment env{ get; set; }
        public Startup(IHostingEnvironment env)
        {
            this.env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        } 
        public void ConfigureServices(IServiceCollection services)
        {
            var isFakeMode = Configuration["ServiceRegistrationMode"] == "Fake";
            if (env.IsDevelopment() && isFakeMode)
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
