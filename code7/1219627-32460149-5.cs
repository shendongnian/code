    public void Configure(
        IApplicationBuilder application,
        IServiceProvider serviceProvider)
    {
        // By type.
        var service1 = (MyService)serviceProvider.GetService(typeof(MyService));
        // Using extension method.
        var service2 = serviceProvider.GetService<MyService>();
        // ...
    }
