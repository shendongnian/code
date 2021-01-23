    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateClientAuthentication(
            ValidateClientAuthenticationContext context)
        {
            context.Skipped();
            return Task.FromResult<object>(null);
        }
        public override Task GrantResourceOwnerCredentials(
            GrantResourceOwnerCredentialsContext context)
        {
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
