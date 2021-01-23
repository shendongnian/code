    public void ConfigureServices(IServiceCollection services)
    {
        //configure DI
        services.AddTransient<IFoo, Foo>();
        
        //Add automapper - scans for Profiles
        services.AddAutoMapper();
        //or specify
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<ViewModelProfile>();
            ...
        });
        ...
