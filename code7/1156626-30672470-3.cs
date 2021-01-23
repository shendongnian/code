    app.UseJwtBearerAuthentication(options => {
        options.AutomaticAuthenticate = true;
        options.Audience = "http://localhost:54540/";
        options.Authority = "http://localhost:54540/";
        options.RequireHttpsMetadata = false;
    });
    
    // Add a new middleware issuing tokens.
    app.UseOpenIdConnectServer(options => {
        options.AllowInsecureHttp = true;
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
                context.Validated(new ClaimsPrincipal(identity));
                return Task.FromResult<object>(null);
            }
        }
    });
