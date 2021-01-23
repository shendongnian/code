    public class Startup
    {
        public static IContainer container { get; set; }
    
        // make this virtual
        public virtual void Configuration(IAppBuilder appBuilder)
        {
            var httpConfig = new HttpConfiguration();
            // have this return the ContainerBuilder instead of the container
            var builder = AutofacSetup.Register(httpConfig)
            container = builder.Build();
            WebApiConfig.Register(httpConfig);
    
    
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(httpConfig);
            appBuilder.UseWebApi(httpConfig);
        }
    }
