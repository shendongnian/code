    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
                                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                    .AllowAnyHeader()));
    }
