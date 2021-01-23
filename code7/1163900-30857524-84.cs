    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by the server.
            app.UseJwtBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Audience = "http://localhost:50000/";
                options.Authority = "http://localhost:50000/";
                // IMPORTANT: when making your token request, add the "resource" parameter
                // containing the URL-encoded address of your API
                // (e.g grant_type=password&username=Username&password=Password&resource=http%3A%2F%2Flocalhost%3A54540%2F).
                // Alternatively, you can also disable audience validation,
                // but it has one downside: id_token will also be accepted by default.
                // Using the "resource" parameter is RECOMMENDED.
                // options.TokenValidationParameters.ValidateAudience = false;
                // Note: by default, IdentityModel beta8 now refuses to initiate non-HTTPS calls.
                // To work around this limitation, the configuration manager is manually
                // instantiated with a document retriever allowing HTTP calls.
                options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    metadataAddress: options.Authority + ".well-known/openid-configuration",
                    configRetriever: new OpenIdConnectConfigurationRetriever(),
                    docRetriever: new HttpDocumentRetriever { RequireHttps = false });
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(configuration =>
            {
                configuration.Options.AllowInsecureHttp = true;
                configuration.Options.AuthorizationEndpointPath = PathString.Empty;
                configuration.Provider = new AuthorizationProvider();
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
