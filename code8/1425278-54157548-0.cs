    public void ConfigureServices(IServiceCollection services)
    {
        .
        .
        .
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "...", Version = "v1" });
            .
            .
            .
            c.AddSecurityDefinition("Bearer", new OAuth2Scheme
            {
                Flow = "password",
                TokenUrl = "/token"
            });
           // It must be here so the Swagger UI works correctly (Swashbuckle.AspNetCore.SwaggerUI, Version=4.0.1.0)
           c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
           {
               {"Bearer", new string[] { }}
           });
        });
        .
        .
        .
    }
