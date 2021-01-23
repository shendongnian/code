    public class SomeController : ApiController
    {
        OAuth2Parameters parameters;
        public string First()
        {
            string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
            return authorizationUrl;
        }
        public void Second(string someAccessCode)
        {
            // I want to reuse the above OAuth2Parameters parameters here:
            parameters.AccessCode = someAccessCode;
            OAuthUtil.GetAccessToken(parameters);
            string accessToken = parameters.AccessToken;
        }
    }
