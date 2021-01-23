    public class Startup
    {
        public Startup(
            IHostingEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory)
        {
        }
    
        public void ConfigureServices(
            IServiceCollection services)
        {
        }
    
        public void Configure(
            IApplicationBuilder application,
            IHostingEnvironment hostingEnvironment,
            IServiceProvider serviceProvider,
            ILoggerFactory loggerfactory,
            IApplicationLifetime applicationLifetime)
        {
        }
    }
