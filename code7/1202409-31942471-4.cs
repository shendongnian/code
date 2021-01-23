    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
             options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:1233")
                                                       .WithMethods("GET")
                                                       .WithHeaders("name")));
        services.AddMvc();
    }
