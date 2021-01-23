        public static class UnityConfig {
           public static IUnityContainer GetConfiguredContainer() {
                var container = new UnityContainer();
                // Register controller
                container.RegisterType<MyController>();
    
                // Register interface
                container.RegisterType<IService, Service>();
    
                //This is done in Startup instead.
                //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
                return container;
        }
    }
