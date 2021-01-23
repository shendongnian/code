    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        services.RegisterApplicationServices(Configuration);
    }
