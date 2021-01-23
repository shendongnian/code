    public class UnityConfiguration() {
       public IUnityContainer Config() {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            // return the container so it can be used for the dependencyresolver.  
            return container;         
       }
    }
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Register Unity with Web API.
            var container = UnityConfiguration.Config();
            config.DependencyResolver = new UnityResolver(container);
            // Your routes...
        }
    }
