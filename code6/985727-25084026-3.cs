    [Fact]
    public void Test()
    {
        var container = new UnityContainer();
        container.RegisterType<IService, CompositeDataService>();
        container.RegisterType<IService, LoggingService>("Logging");
        container.RegisterType<IService, CachingService>("Caching");
        var service = container.Resolve<IService>();
        Assert.IsType<CompositeDataService>(service);
        Assert.Equal(2, ((CompositeDataService)service).services.Count());
    }
