    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);
            ...
        }
    }
