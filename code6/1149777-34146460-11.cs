    class Program
    {
        private static void Main()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            container.RegisterSingleton<ISingletonDependency, SingletonDependency>();
            container.Register<IScopedDependency, ScopedDependency>(Lifestyle.Scoped);
            container.Register<IBrokeredMessageProcessor, BrokeredMessageProcessor>(Lifestyle.Scoped);
            container.Verify();
            var config = new JobHostConfiguration
            {
                JobActivator = new SimpleInjectorJobActivator(container)
            };
            var servicebusConfig = new ServiceBusConfiguration
            {
                ConnectionString = CloudConfigurationManager.GetSetting("MyServiceBusConnectionString")
            };
            config.UseServiceBus(servicebusConfig);
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
