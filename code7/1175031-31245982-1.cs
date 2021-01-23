    public class YourOAuthProvider : OAuthAuthorizationServerProvider
    {
        public string apikey = string.Empty;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (RequestHasValidCredentials(context.UserName, context.Password))
            {
                var id = new ClaimsIdentity(context.Options.AuthenticationType);
                id.AddClaim(new Claim("username", context.UserName));
                context.Validated(id);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }            
        }
    }
