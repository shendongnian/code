    public static void Main()
    {
        try
        {
            var container = ConfigureServiceContainer();
            ServiceRuntime.RegisterServiceAsync(
                "MyConsumingServiceType",
                context => container.Resolve<MyConsumingService>(new TypedParameter(typeof(StatefulServiceContext), context))).GetAwaiter().GetResult();
            ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(MyConsumingService).Name);
            Thread.Sleep(Timeout.Infinite);
        }
        catch (Exception e)
        {
            ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
            throw;
        }
    }
    private static IContainer ConfigureServiceContainer()
    {
        var containerBuilder = new ContainerBuilder();
        // Other registrations...
        
        containerBuilder.RegisterModule<MyAppModule>();
        return containerBuilder.Build();
    }
