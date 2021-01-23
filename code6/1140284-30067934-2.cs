    public class Startup
    {
    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddRouting();
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        "YQ Controller",
                        "{*src}",
                        new { controller = "YQFile", action = "OnDemand" },
                        new { src = @"(.*?)\.(yqs)" }
                    );
                })
                .UseStaticFiles()
                .UseDefaultFiles()
                .UseFileServer();
        }
    }
