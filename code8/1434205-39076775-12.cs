        public IHostingEnvironment env{ get; set; }
        public Startup(IHostingEnvironment env)
        {
            this.env = env;
        } 
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsDevelopment())
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
