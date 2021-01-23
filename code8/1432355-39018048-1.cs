    public override Task ValidateTokenRequest(ValidateTokenRequestContext context) {
        // Reject the token request if it doesn't use grant_type=password, refresh_token
        // or urn:ietf:params:oauth:grant-type:facebook_access_token.
        if (!context.Request.IsPasswordGrantType() &&
            !context.Request.IsRefreshTokenGrantType() &&
             context.Request.GrantType != "urn:ietf:params:oauth:grant-type:facebook_access_token") {
            context.Reject(
                error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
                description: "The specified grant type is not supported by this server.");
            return Task.FromResult(0);
        }
        // Reject the token request if the assertion parameter is missing.
        if (context.Request.GrantType == "urn:ietf:params:oauth:grant-type:facebook_access_token" &&
            string.IsNullOrEmpty(context.Request.Assertion)) {
            context.Reject(
                error: OpenIdConnectConstants.Errors.InvalidRequest,
                description: "The assertion is missing.");
            return Task.FromResult(0);
        }
        // Since there's only one application and since it's a public client
        // (i.e a client that cannot keep its credentials private), call Skip()
        // to inform the server the request should be accepted without 
        // enforcing client authentication.
        context.Skip();
        return Task.FromResult(0);
    }
    public override Task HandleTokenRequest(HandleTokenRequestContext context) {
        // Only handle grant_type=password and urn:ietf:params:oauth:grant-type:facebook_access_token
        // requests and let the OpenID Connect server middleware handle the refresh token requests.
        if (context.Request.IsPasswordGrantType()) {
            // Skipped for brevity.
        }
        else if (context.Request.GrantType == "urn:ietf:params:oauth:grant-type:facebook_access_token") {
            // The assertion corresponds to the Facebook access token.
            var assertion = context.Request.Assertion;
            // Create a new ClaimsIdentity containing the claims that
            // will be used to create an id_token and/or an access token.
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
            // Validate the access token using Facebook's token validation
            // endpoint and add the user claims you retrieved here.
            identity.AddClaim(ClaimTypes.NameIdentifier, "FB user identifier");
            // Create a new authentication ticket holding the user identity.
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                OpenIdConnectServerDefaults.AuthenticationScheme);
            // Set the list of scopes granted to the client application.
            ticket.SetScopes(new[] {
                /* openid: */ OpenIdConnectConstants.Scopes.OpenId,
                /* email: */ OpenIdConnectConstants.Scopes.Email,
                /* profile: */ OpenIdConnectConstants.Scopes.Profile,
                /* offline_access: */ OpenIdConnectConstants.Scopes.OfflineAccess
            }.Intersect(context.Request.GetScopes()));
            context.Validate(ticket);
        }
        return Task.FromResult(0);
    }
