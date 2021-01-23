    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IServer, ConsoleAppRunner>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
