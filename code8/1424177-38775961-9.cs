    public void ConfigureServices(IServiceCollection services)
    {
        // (Other code...)
        services.AddTransient<IViewRenderingService, ViewRenderingService>();
        services.AddMvc();
    }
