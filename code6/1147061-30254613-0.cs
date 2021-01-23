    // Create OAuth Credential.
    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        new ClientSecrets
        {
            ClientId = "CLIENT_ID",
            ClientSecret = "CLIENT_SECRET"
        },
        new[] { GmailService.Scope.GmailModify },
        "user",
        CancellationToken.None).Result;
    
    // Create the service.
    var service = new GmailService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = credential,
        ApplicationName = "Draft Sender",
    });
    
    ListDraftsResponse draftsResponse = service.Users.Drafts.List("me").Execute();
