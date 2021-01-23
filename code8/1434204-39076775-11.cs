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
