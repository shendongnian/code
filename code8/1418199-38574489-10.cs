    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        // if < .NET Core 2.2 use this
        //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // Other code...
    }
