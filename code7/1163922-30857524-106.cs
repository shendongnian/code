    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateClientAuthentication(
            ValidateClientAuthenticationContext context)
        {
            // Since there's only one application and since it's a public client
            // (i.e a client that cannot keep its credentials private), call Skipped()
            // to inform the server the request should be accepted without 
            // enforcing client authentication.
            context.Skipped();
            return Task.FromResult(0);
        }
        public override Task GrantResourceOwnerCredentials(
            GrantResourceOwnerCredentialsContext context)
        {
            // Validate the credentials here (e.g using ASP.NET Identity).
            // You can call Rejected() with an error code/description to reject
            // the request and return a message to the caller.
            var identity = 
                new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, "todo");
            // By default, claims are not serialized in the access and identity tokens.
            // Use the overload taking a "destination" to make sure your claims
            // are correctly inserted in the appropriate tokens.
            identity.AddClaim("urn:customclaim", "value", "token id_token");
            var principal = new ClaimsPrincipal(identity);
            context.Validated(principal);
            return Task.FromResult<object>(null);
        }
    }
