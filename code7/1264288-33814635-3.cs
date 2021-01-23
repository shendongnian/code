    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCaching();
        services.AddSession(/* options go here */);
    }
