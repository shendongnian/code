    public class AAGoogleAuthorizationCodeRequestUrl : GoogleAuthorizationCodeRequestUrl
    {
        [Google.Apis.Util.RequestParameterAttribute("request_visible_actions", Google.Apis.Util.RequestParameterType.Query)]
        public string VisibleActions { get; set; }
        public AAGoogleAuthorizationCodeRequestUrl(Uri authorizationServerUrl)
            : base(authorizationServerUrl)
        {
        }
    }
    public class AAGoogleAuthorizationCodeFlow : AuthorizationCodeFlow
    {
        /// <summary>Constructs a new Google authorization code flow.</summary>
        public AAGoogleAuthorizationCodeFlow(AuthorizationCodeFlow.Initializer initializer)
            : base(initializer)
        {
        }
        public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
        {
            return new AAGoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl))
            {
                ClientId = ClientSecrets.ClientId,
                Scope = string.Join(" ", Scopes),
                RedirectUri = redirectUri,
                VisibleActions = "http://schemas.google.com/AddActivity"
            };
        }
    }
