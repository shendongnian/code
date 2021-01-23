    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        private static void Main()
        {
            // Get the IoC Container
            var container = SimpleInjectorBootstrapper();
            // Configure the job host
            var config = new JobHostConfiguration
            {
                JobActivator = new SimpleInjectorJobActivator(container)
            };
            // Set the service bus connection string
            var servicebusConfig = new ServiceBusConfiguration
            {
                ConnectionString = CloudConfigurationManager.GetSetting("MyServiceBusConnectionString")
            };
            config.UseServiceBus(servicebusConfig);
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
        private static Container SimpleInjectorBootstrapper()
        {
            var container = new Container();
            // Each time a ISingletonDependency is needed, the same instance of the SingletonDependency class is returned.
            container.RegisterSingleton<ISingletonDependency, SingletonDependency>();
            // Each time a IScopedDependency is needed, a new instance of the ScopedDependency class is returned.
            container.RegisterSingleton<IScopedDependency, ScopedDependency>();
            container.Verify();
            return container;
        }
    }
