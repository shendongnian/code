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
            StaticFileOptions option = new StaticFileOptions();
            FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider) option.ContentTypeProvider;
            contentTypeProvider.Mappings.Add(".yqs", "text/plain");   
    
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
                .UseStaticFiles(option)
                .UseDefaultFiles()
                .UseFileServer();
        }
    }
