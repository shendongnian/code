    public sealed class CompositionRoot : IDisposable, IHttpControllerActivator
    {
        // Singleton-scoped services are declared here...
        private readonly IExampleSingleton _singleton;
        
        // pass in any true singletons i.e. cross application instance singletons
        public CompositionRoot()
        {
            _singleton = new Singleton();
        }
        
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            // Per-Request-scoped services are declared and initialized here
            var uow = new FerreroUow(); // not sure what scope this should have...
            if (controllerType == typeof(HomeController))
            {
                // Transient services are created and directly injected here
                return new HomeController(ferreroUow);
            }
            // other controller types
            
            var argumentException = new ArgumentException("Unexpected controller type! " + controllerType.Name, nameof(controllerType));
            Log.Error(argumentException, "don't know how to instantiate a {controllerType}", controllerType.Name);
            throw argumentException;
        }
        public void Dispose()
        {
            _singleton.Dispose(); // if needed
        }
    }
