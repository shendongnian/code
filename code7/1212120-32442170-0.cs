    //in Startup class
    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
    {
        Provider = new QueryStringOAuthBearerProvider(),
        //your settings
    });
    
    //implementation
    public class QueryStringOAuthBearerProvider : OAuthBearerAuthenticationProvider
    {
        private const string AccessTokenQueryKey = "access_token";
        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            //check if token found in the default location - "Authorization: Bearer <token>" header
            if (string.IsNullOrEmpty(context.Token))
            {
                var token = context.Request.Query.Get(AccessTokenQueryKey);
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
            }
            return Task.FromResult<object>(null);
        }
    }
