    public void ConfigureServices(IServiceCollection services)
    {
        // ...other code...
        // Add services to DI container
        services.AddTransient<LogErrorsFilterAttribute>();
        services.AddMvc(options =>
        {
            // Add error logging attribute to every request
            options.Filters.Add(new ServiceFilterAttribute(typeof(LogErrorsFilterAttribute)));
        });
        // ...other code...
    }
