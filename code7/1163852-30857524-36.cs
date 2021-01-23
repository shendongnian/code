    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateClientAuthentication(
            ValidateClientAuthenticationNotification notification)
        {
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
