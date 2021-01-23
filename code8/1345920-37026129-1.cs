    [assembly: OwinStartup(typeof(Startup))]
    namespace API.MyApi
    {
    
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var webApiConfiguration = new HttpConfiguration();
    
                webApiConfiguration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                    );
    
                app.UseNinjectMiddleware(CreateKernel);
                app.UseNinjectWebApi(webApiConfiguration);
            }
    
            private static StandardKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
    
                var modules = new List<INinjectModule>
                {
                    new BusinessBindings(),
                    new DataBindings()
                };
                kernel.Load(modules);
                return kernel;
            }
    
        }
    }
