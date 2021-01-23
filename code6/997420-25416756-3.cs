    Bind<IMyClient>().ToMethod(x => SetupClient(x)).InRequestScope();
    
    private IMyClient SetupClient(IContext context)
    {
        string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        var client = new MyClient(apiKey);
        if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            var tokenClaim = identity.Claims.First(c => c.Type == ClaimTypes.Sid);
            client.AddCredentials(tokenClaim.Value);
        }
        return client;
    }
