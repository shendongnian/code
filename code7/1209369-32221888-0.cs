    public static IServiceProvider __serviceProvider;
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<IState, State>();
        __serviceProvider = services.BuildServiceProvider();
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseSignalR();
    }
