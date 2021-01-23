    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry(Configuration);
        services.AddMvc();
        services.AddTransient<ITestService, TestService>();
    }
