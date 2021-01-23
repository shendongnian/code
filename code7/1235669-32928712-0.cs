    public interface ICustomClass {}
    public class CustomClass : ICustomClass {}
    public CustomClass _stuffInstance = new CustomClass();
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
            builder.RegisterInstance(_stuffInstance).As<ICustomClass>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
