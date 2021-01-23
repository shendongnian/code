    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class RootServiceExtensions //you can pick a better name
        {
            //again pick a better name
            public static IServiceCollection AddRootServices(this IServiceCollection services, string connectionString) 
            {
                // Choose Scope, Singleton or Transient method
                services.AddSingleton<IRootService, RootService>();
                services.AddSingleton<INestedService, NestedService>(_ => 
                  new NestedService(connectionString));
            }
        }
    }
