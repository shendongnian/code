    public void Configure(
        IApplicationBuilder application,
        IServiceProvider serviceProvider)
    {
        MyService myService = serviceProvider.GetService(typeof(MyService));
        // ...
    }
