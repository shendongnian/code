    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddDistributedMemoryCache();
        }
    }
