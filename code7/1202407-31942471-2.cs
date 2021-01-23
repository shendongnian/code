    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors();
        services.ConfigureCors(options =>
             options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:1233")
                                                       .WithMethods("GET")
                                                       .WithHeaders("name")));
    }
