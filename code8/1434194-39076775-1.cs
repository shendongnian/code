        public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
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
