    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
                // Add a new middleware validating the encrypted
                // access tokens issued by the OIDC server.
                .AddOAuthValidation()
                // Add a new middleware issuing tokens.
                .AddOpenIdConnectServer(options =>
                {
                    options.TokenEndpointPath = "/connect/token";
                    // Override OnValidateTokenRequest to skip client authentication.
                    options.Provider.OnValidateTokenRequest = context =>
                    {
                        // Reject the token requests that don't use
                        // grant_type=password or grant_type=refresh_token.
                        if (!context.Request.IsPasswordGrantType() &&
                            !context.Request.IsRefreshTokenGrantType())
                        {
                            context.Reject(
                                error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
                                description: "Only grant_type=password and refresh_token " +
                                             "requests are accepted by this server.");
                            return Task.CompletedTask;
                        }
                        // Since there's only one application and since it's a public client
                        // (i.e a client that cannot keep its credentials private),
                        // call Skip() to inform the server the request should be
                        // accepted without enforcing client authentication.
                        context.Skip();
                        return Task.CompletedTask;
                    };
                    // Override OnHandleTokenRequest to support
                    // grant_type=password token requests.
                    options.Provider.OnHandleTokenRequest = context =>
                    {
                        // Only handle grant_type=password token requests and let the
                        // OpenID Connect server middleware handle the other grant types.
                        if (context.Request.IsPasswordGrantType())
                        {
                            // Do your credentials validation here.
                            // Note: you can call Reject() with a message
                            // to indicate that authentication failed.
                            var identity = new ClaimsIdentity(context.Scheme.Name);
                            identity.AddClaim(OpenIdConnectConstants.Claims.Subject, "[unique id]");
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
                                context.Scheme.Name);
                        
                            // Call SetScopes with the list of scopes you want to grant
                            // (specify offline_access to issue a refresh token).
                            ticket.SetScopes("profile", "offline_access");
                        
                            context.Validate(ticket);
                        }
                        
                        return Task.CompletedTask;
                    };
                });
        }
    }
