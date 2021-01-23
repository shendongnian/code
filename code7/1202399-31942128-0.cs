    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.ConfigureCors(options =>
                                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                    .AllowAnyHeader()));
    }
