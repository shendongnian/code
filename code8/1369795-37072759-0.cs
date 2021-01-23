    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //...
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
    
            DependencyConfig.InjectDependencies(app, httpConfig);
        }
     }
    
    public class DependencyConfig
    {
        public static void InjectDependencies(IAppBuilder app, HttpConfiguration config)
        {
            // ...
            container.RegisterWebApiControllers(config);
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            // ...
        }
    }
