    public void Configure(
        IApplicationBuilder application,
        IServiceProvider serviceProvider)
    {
        MyService myService = (MyService)serviceProvider.GetService(typeof(MyService));
        // ...
    }
