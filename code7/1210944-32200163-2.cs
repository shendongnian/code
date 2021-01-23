    namespace www
    {
        public class Startup
        {
            private IHostingEnvironment _env;
    
            public Startup(IHostingEnvironment env)
            {
                _env = env;
                Environment.rootPath = env.WebRootPath;
            }
    
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseStaticFiles();
                app.UseMvc();
            }
        }
    }
