        // Import Nuget package: Microsoft.Identity.Client
        public class AuthenticationService
        {
             private readonly List<string> _scopes;
             private readonly IConfidentialClientApplication _app;
            public AuthenticationService(AuthenticationConfiguration authentication)
            {
                 _app = ConfidentialClientApplicationBuilder
                             .Create(authentication.ClientId)
                             .WithClientSecret(authentication.ClientSecret)
                             .WithAuthority(authentication.Authority)
                             .Build();
               _scopes = new List<string> {$"{authentication.Audience}/.default"};
           }
           public async Task<string> GetAccessToken()
           {
               var authenticationResult = await _app.AcquireTokenForClient(_scopes) 
                                                    .ExecuteAsync();
               return authenticationResult.AccessToken;
           }
       }
