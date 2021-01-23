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
            var principal = new ClaimsPrincipal(identity);
            notification.Validated(principal);
            return Task.FromResult<object>(null);
        }
    }
