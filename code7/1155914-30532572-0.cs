    // You'll need to include the following namespaces
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    // This is the Application_Start event from the Global.asax file.
    protected void Application_Start() {
        // Create the container as usual.
        var container = new Container();
    
        // Register your types, for instance using the RegisterWebApiRequest
        // extension from the integration package:
        container.RegisterWebApiRequest<IUserRepository, SqlUserRepository>();
    
        // This is an extension method from the integration package.
        container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
    
        container.Verify();
    
        GlobalConfiguration.Configuration.DependencyResolver =
            new SimpleInjectorWebApiDependencyResolver(container);
    
        // Here your usual Web API configuration stuff.
    }
