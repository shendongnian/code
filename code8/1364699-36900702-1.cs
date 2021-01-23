    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration()
                .ConfigureRouting()
                .ConfigureDependencyInjection();
            
            app.UseWebApi(config);
            
            // protip: use OWIN error page instead of ASP.NET yellow pages for better diagnostics 
            // Install-Package Microsoft.Owin.Diagnostics
            app.UseErrorPage(ErrorPageOptions.ShowAll); 
        }
        
        private static HttpConfiguration ConfigureRouting(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "default", 
                routeTemplate: "/", 
                defaults: new { controller = "values" });
            return config;
        }
        
        private static HttpConfiguration ConfigureDependencyInjection(this HttpConfiguration config)
        {
            var c = new Container();
            c.Register<ISession>(Made.Of(() => GetSession(Arg.Of<HttpRequestMessage>())));
            c.Register<IWidgetService, WidgetService>(Reuse.Singleton);
            c.Register<IWidgetRepository, WidgetRepository>(Reuse.Singleton);
            c.WithWebApi(config);
            return config;
        }
    }
