    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a new middleware validating access tokens issued by the server.
            app.UseJwtBearerAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.Authority = "http://localhost:50000/";
                // Audience validation is only useful if you have multiple
                // distinct resource servers (= multiple APIs).
                // See https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server/issues/94#issuecomment-118360381 for more information.
                options.TokenValidationParameters.ValidateAudience = false;
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
