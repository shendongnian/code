            public class SampleAuthorizationServerProvider : OAuthAuthorizationServerProvider, IOAuthAuthorizationServerProvider
            {
               public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
                    {
            // do AD check or other stuff needed to validate the user here
                var ticket = new AuthenticationTicket(identity, props); // props here is a AuthenticationProperties Dictionnary with other stuff that you want in your JwtToken
        context.Validated(ticket);
            }
    
            public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
    //do some check...
    context.Validated();
    }
        }
