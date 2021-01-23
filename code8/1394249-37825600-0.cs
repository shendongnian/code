    string clientId = "";
    string clientsecret = "";
    string tenant = "";
    string resourceURL = "https://graph.microsoft.com";
    string authority = "https://login.microsoftonline.com/" + tenant + "/oauth2/token";
    string userMail = "";
    var accessToken = new TokenHelper(authority).AcquireTokenAsync(clientId, clientsecret, resourceURL);
      var graphserviceClient = new GraphServiceClient(
       new DelegateAuthenticationProvider(
           (requestMessage) =>
           {
               requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
               return Task.FromResult(0);
           }));
            var items = await graphserviceClient.Users[user].Messages.Request().OrderBy("receivedDateTime desc").GetAsync();
            foreach (var item in items)
            {
                Console.WriteLine(item.Subject);
            }
    class TokenHelper
    {
        AuthenticationContext authContext;
        public TokenHelper(string authUri)
        {
            authContext = new AuthenticationContext(authUri);
        }
        public string AcquireTokenAsync(string clientId, string secret,string resrouceURL)
        {
            var credential = new ClientCredential(clientId: clientId, clientSecret: secret);
            var result = authContext.AcquireTokenAsync(resrouceURL, credential).Result;
            return result.AccessToken;
        }
    }
