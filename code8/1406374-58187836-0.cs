    public void ConfigureServices(IServiceCollection services)
    {
    ...
        services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
