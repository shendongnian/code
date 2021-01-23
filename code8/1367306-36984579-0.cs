    public class MyCustomTokenProvider : IOAuthBearerAuthenticationProvider
    {
        public Task RequestToken(OAuthRequestTokenContext context)
        {
            if (context.Token == null)
            {
                //try get from cookie
                var tokenCookie = context.Request.Cookies["myCookieName"];
    
                if (tokenCookie != null)
                {
                    context.Token = tokenCookie;
                }
            }
    
            return Task.FromResult(0);
        }
    
        public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            throw new NotImplementedException();
        }
    
        public Task ApplyChallenge(OAuthChallengeContext context)
        {
            throw new NotImplementedException();
        }
    }
