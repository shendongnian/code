    ClientSecrets secrets = new ClientSecrets
    {
    ClientId = "***",
    ClientSecret = "***"
    };
    IEnumerable<string> scopes = new[] { PlusService.Scope.UserinfoEmail, PlusService.Scope.UserinfoProfile };
        
    IAuthorizationCodeFlow flow =
    new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
         ClientSecrets = secrets,
         Scopes = scopes
    });                               
                        
    TokenResponse token = flow.ExchangeCodeForTokenAsync("", code, 
    "https://localhost:44388/TestLogin/Redirect", //This is the same url that I have for credentials
       CancellationToken.None).Result;
