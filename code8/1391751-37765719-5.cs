        public class RootServiceFactory : IRootServiceFactory 
        {
            // in case you need other dependencies, that can be resolved by DI
            private readonly IServiceCollection services;
            public RootServiceCollection(IServiceCollection services)
            {
                this.services = services;
            }
            public CreateInstance(string connectionString) 
            {
                // instantiate service that needs runtime parameter
                var nestedService = new NestedService(connectionString);
                // resolve another service that doesn't need runtime parameter
                var otherDependency = services.GetService<IOtherService>()
                // pass both into the RootService constructor and return it
                return new RootService(otherDependency, nestedDependency);
            }
        }
