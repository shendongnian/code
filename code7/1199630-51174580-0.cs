    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            var token = context.AccessToken;
            return base.TokenEndpointResponse(context);
        }
    }
