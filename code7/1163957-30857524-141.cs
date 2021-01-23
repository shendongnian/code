    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            // Since there's only one application and since it's a public client
            // (i.e a client that cannot keep its credentials private), call Skip()
            // to inform the server that the request should be accepted without 
            // enforcing client authentication.
            context.Skip();
            return Task.FromResult(0);
        }
        public override Task GrantResourceOwnerCredentials(
            GrantResourceOwnerCredentialsContext context)
        {
            // Validate the credentials here (e.g using ASP.NET Identity).
            // You can call Reject() with an error code/description to reject
            // the request and return a message to the caller.
            var identity = new ClaimsIdentity(context.Options.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, "[unique identifier]");
            // By default, claims are not serialized in the access and identity tokens.
            // Use the overload taking a "destinations" parameter to make sure 
            // your claims are correctly serialized in the appropriate tokens.
            identity.AddClaim("urn:customclaim", "value",
                OpenIdConnectConstants.Destinations.AccessToken,
                OpenIdConnectConstants.Destinations.IdentityToken);
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                context.Options.AuthenticationScheme);
            // Call SetResources with the list of resource servers
            // the access token should be issued for.
            ticket.SetResources("resource_server_1");
            // Call SetScopes with the list of scopes you want to grant
            // (specify offline_access to issue a refresh token).
            ticket.SetScopes("profile", "offline_access");
            context.Validate(ticket);
            return Task.FromResult(0);
        }
    }
