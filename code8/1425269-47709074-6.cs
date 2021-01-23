    services.AddSwaggerGen(c =>
    {
        // Your custom configuration
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        c.DescribeAllEnumsAsStrings();
        // JWT-token authentication by password
        c.AddSecurityDefinition("oauth2", new OAuth2Scheme
        {
            Type = "oauth2",
            Flow = "password",
            TokenUrl = Path.Combine(HostingEnvironment.WebRootPath, "/token"),
            // Optional scopes
            //Scopes = new Dictionary<string, string>
            //{
            //    { "api-name", "my api" },
            //}
        });
    });
