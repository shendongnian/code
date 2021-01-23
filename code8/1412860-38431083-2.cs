    public interface ISingleton : IDisposable { }
    public class TransientDependency { }
    public class Singleton : ISingleton
    {
        public void Dispose() { }
    }
    // IHttpControllerActivator is for WebApi, IControllerFactory for MVC
    public class CompositionRoot : IDisposable, IHttpControllerActivator, IControllerFactory
    {
        private readonly ISingleton _singleton;
        // pass in any true singletons i.e. cross application instance singletons
        public CompositionRoot()
        {
            // intitialise any application instance singletons
            _singleton = new Singleton();
        }
        public void Dispose()
        {
            _singleton.Dispose();
        }
        // Web API
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            // Per-Request-scoped services are declared and initialized here
            if (controllerType == typeof(SomeApiController))
            {
                // Transient services are created and directly injected here
                return new SomeApiController(_singleton, new TransientDependency());
            }
            var argumentException = new ArgumentException(@"Unexpected controller type! " + controllerType.Name,
                nameof(controllerType));
            Log.Error(argumentException, "don't know how to instantiate API controller: {controllerType}", controllerType.Name);
            throw argumentException;
        }
        // MVC
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower() == "home")
            {
                return new HomeController(_singleton, new TransientDependency());
            }
            var argumentException = new ArgumentException(@"Unexpected controller! " + controllerName);
            Log.Error("don't know how to instantiate MVC controller: {controllerType}. redirecting to help", controllerName);
            throw argumentException; // Alternatively would return some default Page Not Found placeholder controller;
        }
        // MVC
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default; 
        }
        // MVC
        public void ReleaseController(IController controller)
        {
            // anything to clean up?
        }
    }
    
    public static class DependencyInjection
    {
        public static void WireUp()
        {
            var compositionRoot = new CompositionRoot();
            
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(compositionRoot);
            System.Web.Http.GlobalConfiguration.Configuration.Services.Replace(typeof (IHttpControllerActivator), compositionRoot);
        }
    }
      
