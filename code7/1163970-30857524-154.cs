    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by the server.
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                Audience = "resource_server_1",
                Authority = "http://localhost:50000/",
                RequireHttpsMetadata = false
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options =>
            {
                // Disable the HTTPS requirement.
                options.AllowInsecureHttp = true;
                // Disable the authorization endpoint as it's not used in this scenario.
                options.AuthorizationEndpointPath = PathString.Empty;
                options.Provider = new AuthorizationProvider();
                // Force the OpenID Connect server middleware to use JWT
                // instead of the default opaque/encrypted format.
                options.AccessTokenHandler = new JwtSecurityTokenHandler();
            });
            app.UseMvc();
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
