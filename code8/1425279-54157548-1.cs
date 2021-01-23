    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        .
        .
        .
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "...");
            // Provide client ID, client secret, realm and application name (if need)
            c.OAuthClientId("...");
            c.OAuthClientSecret("...");
            c.OAuthRealm("...");
            c.OAuthAppName("...");
        });
        .
        .
        .
    }
