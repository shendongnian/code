    // Register the Swagger generator, defining 1 or more Swagger documents
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info
        {
            Version = "v1",
            Title = "Core API",
            Description = "ASP.NET Core API",
            TermsOfService = "None",
            Contact = new Contact
            {
                Name = "Raj Kumar",
                Email = ""
            },
            License = new License
            {
                Name = "Demo"
            }
        });
        c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = "header",
            Type = "apiKey"
        });
        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
        {
        {"Bearer",new string[]{}}
        });
    });
