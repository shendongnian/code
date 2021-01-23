    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            this.ConfigurePersistenceServices(services);
        }
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseMvc();
            this.ConfigurePersistence(serviceProvider);
            app.Run(async context => { await context.Response.WriteAsync("Hello!"); });
        }
        private void ConfigurePersistence(IServiceProvider serviceProvider)
        {
            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            unitOfWork.Create(new TodoItem("Test"));
            unitOfWork.Save();
        }
        private void ConfigurePersistenceServices(IServiceCollection services)
        {
            services
                .AddEntityFramework()
                .AddInMemoryStore()
                .AddDbContext<FarmContext>(options =>
                {
                    options.UseInMemoryStore(persist: true);
                });
            // TODO: Use per request not singleton!
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
