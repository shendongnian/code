    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateClientAuthentication(
            ValidateClientAuthenticationNotification notification)
        {
            // Note: if you're using the beta2 version from NuGet.org,
            // make sure to set ClientId to string.Empty to work around
            // a bug that has been fixed in beta3 (for ASP.NET beta8). 
            notification.ClientId = string.Empty;
            notification.Validated();
            return Task.FromResult<object>(null);
        }
        public override Task GrantResourceOwnerCredentials(
            GrantResourceOwnerCredentialsNotification notification)
        {
            var identity = 
                new ClaimsIdentity(OpenIdConnectDefaults.AuthenticationScheme);
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
