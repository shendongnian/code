    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override async Task ValidateClientAuthentication(
            ValidateClientAuthenticationNotification notification)
        {
            await Task.Delay(1);
            notification.Validated();
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
