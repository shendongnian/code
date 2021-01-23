    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication();
            services.AddDistributedMemoryCache();
        }
        public void Configure(IApplicationBuilder app) {
            // Add a new middleware validating the encrypted
            // access tokens issued by the OIDC server.
            app.UseOAuthValidation();
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options => {
                options.Provider = new OpenIdConnectServerProvider {
                    // Override OnValidateTokenRequest to skip client authentication.
                    OnValidateTokenRequest = context => {
                        // Call Skip() since JS applications cannot
                        // keep their credentials secret.
                        context.Skip();
                        return Task.FromResult(0);
                    },
                    // Override OnGrantResourceOwnerCredentials
                    // to support grant_type=password requests.
                    OnGrantResourceOwnerCredentials = context => {
                        // Do your credentials validation here.
                        // Note: you can call Reject() with a message
                        // to indicate that authentication failed.
                        var identity = new ClaimsIdentity(
                            context.Options.AuthenticationScheme);
                        identity.AddClaim(ClaimTypes.NameIdentifier, "[unique id]");
                        // By default, claims are not serialized
                        // in the access and identity tokens.
                        // Use the overload taking a "destinations"
                        // parameter to make sure your claims
                        // are correctly inserted in the appropriate tokens.
                        identity.AddClaim("urn:customclaim", "value",
                            OpenIdConnectConstants.Destinations.AccessToken,
                            OpenIdConnectConstants.Destinations.IdentityToken);
                        var ticket = new AuthenticationTicket(
                            new ClaimsPrincipal(identity),
                            new AuthenticationProperties(),
                            context.Options.AuthenticationScheme);
                        // Call SetScopes with the list of scopes you want to grant
                        // (specify offline_access to issue a refresh token).
                        ticket.SetScopes("profile", "offline_access");
                        context.Validate(ticket);
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
