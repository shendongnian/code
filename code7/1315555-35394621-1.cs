    public class SomeController : ApiController
    {
        OAuth2Parameters _parameters;
 
        private Parameters {
          get {
            if (_parameters == null) {
              _parameters = new OAuth2Parameters();
              _parameters .ClientId = "someClientID";
              _parameters .ClientSecret = "someClientSecret";
              _parameters .RedirectUri = "someRedirectUri";
              _parameters .Scope = "someScope";
            }
            return _parameters;
          }
        }
        public string First()
        {
            string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(Parameters);
            return authorizationUrl;
        }
        public void Second(string someAccessCode)
        {
            // I want to reuse the above OAuth2Parameters parameters here:
            parameters.AccessCode = someAccessCode;
            OAuthUtil.GetAccessToken(Parameters);
            string accessToken = Parameters.AccessToken;
        }
    }
