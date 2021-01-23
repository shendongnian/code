    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors(options =>
             options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:1233")
                                                       .WithMethods("GET")
                                                       .WithHeaders("name")));
    }
