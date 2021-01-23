    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
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
                // Enable the token endpoint.
                options.TokenEndpointPath = "/connect/token";
                options.Provider = new AuthorizationProvider();
                // Force the OpenID Connect server middleware to use JWT
                // instead of the default opaque/encrypted format.
                options.AccessTokenHandler = new JwtSecurityTokenHandler
                {
                    InboundClaimTypeMap = new Dictionary<string, string>(),
                    OutboundClaimTypeMap = new Dictionary<string, string>()
                };
                // Register an ephemeral signing key, used to protect the JWT tokens.
                // On production, you'd likely prefer using a signing certificate.
                options.SigningCredentials.AddEphemeralKey();
            });
            app.UseMvc();
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
