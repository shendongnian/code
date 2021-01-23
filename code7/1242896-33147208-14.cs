    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication();
            services.AddCaching();
        }
        public void Configure(IApplicationBuilder app) {
            // Add a new middleware validating access tokens issued by the OIDC server.
            app.UseJwtBearerAuthentication(options => {
                options.AutomaticAuthentication = true;
                options.Authority = "resource_server_1";
                options.RequireHttpsMetadata = false;
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options => {
                options.Provider = new OpenIdConnectServerProvider {
                    // Override OnValidateClientAuthentication to skip client authentication.
                    OnValidateClientAuthentication = context => {
                        // Call Skipped() since JS applications cannot keep their credentials secret.
                        context.Skipped();
                        return Task.FromResult<object>(null);
                    },
                    // Override OnGrantResourceOwnerCredentials to support grant_type=password.
                    OnGrantResourceOwnerCredentials = context => {
                        // Do your credentials validation here.
                        // Note: you can call Rejected() with a message
                        // to indicate that authentication failed.
                        var identity = new ClaimsIdentity(OpenIdConnectDefaults.AuthenticationScheme);
                        identity.AddClaim(ClaimTypes.NameIdentifier, "todo");
                        // By default, claims are not serialized in the access and identity tokens.
                        // Use the overload taking a "destination" to make sure your claims
                        // are correctly inserted in the appropriate tokens.
                        identity.AddClaim("urn:customclaim", "value", "token id_token");
                        var ticket = new AuthenticationTicket(
                            new ClaimsPrincipal(identity),
                            new AuthenticationProperties(),
                            context.Options.AuthenticationScheme);
                        // Call SetResources with the list of resource servers
                        // the access token should be issued for.
                        ticket.SetResources(new[] { "resource_server_1" });
                        // Call SetScopes with the list of scopes you want to grant
                        // (specify offline_access to issue a refresh token).
                        ticket.SetScopes(new[] { "profile", "offline_access" });
                        context.Validated(ticket);
                        return Task.FromResult<object>(null);
                    }
                }
            });
            app.UseMvc();
        }
    }
