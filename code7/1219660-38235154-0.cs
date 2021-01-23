    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddApplicationInsightsTelemetry(Configuration);
        services.AddMvc();
    }
