    public void ConfigureServices(IServiceCollection services)
    {
        .
        .
        .
        services.AddLogging(
        builder =>
        {
            builder.AddFilter("Microsoft", LogLevel.Warning)
                   .AddFilter("System", LogLevel.Warning)
                   .AddFilter("NToastNotify", LogLevel.Warning)
                   .AddConsole();
        });
    }
