    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication();
            services.AddCaching();
        }
        public void Configure(IApplicationBuilder app) {
            // Add a new middleware validating access tokens issued by the OIDC server.
            app.UseOAuthBearerAuthentication(options => {
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
            app.UseOpenIdConnectServer(configuration => {
                configuration.Options.AllowInsecureHttp = true;
                configuration.Provider = new OpenIdConnectServerProvider {
                    // Override OnValidateClientAuthentication to skip client authentication.
                    OnValidateClientAuthentication = context => {
                        notification.Skipped();
                        return Task.FromResult<object>(null);
                    },
                    // Override OnGrantResourceOwnerCredentials to support grant_type=password.
                    OnGrantResourceOwnerCredentials = context => {
                        var identity = new ClaimsIdentity(OpenIdConnectDefaults.AuthenticationScheme);
                        identity.AddClaim(ClaimTypes.NameIdentifier, "todo");
                        // By default, claims are not serialized in the access and identity tokens.
                        // Use the overload taking a "destination" to make sure your claims
                        // are correctly inserted in the appropriate tokens.
                        identity.AddClaim("urn:customclaim", "value", "token id_token");
                        var principal = new ClaimsPrincipal(identity);
                        notification.Validated(principal);
                        return Task.FromResult<object>(null);
                    }
                }
            });
            app.UseMvc();
        }
    }
