    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration["Data:ConnectionString"];
        services.AddRootServices(connectionString);
    }
