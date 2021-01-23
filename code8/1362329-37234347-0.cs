    public static class BootstrapConfig
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // DbContext
            services.AddScoped<DbContext>(x => new ApplicationContext(configuration["Data:ApplicationContext:ConnectionString"]));
        }
    }
