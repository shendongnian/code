    using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
    {
        var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecretsStream = stream,
            Scopes = new[] { DriveService.Scope.DriveReadonly },
            DataStore = new FileDataStore(credPath, true)
        });
    
        credential = new UserCredential(flow, userId,
            await flow.LoadTokenAsync(userId, CancellationToken.None)
        );
    
        bool res = await credential.RevokeTokenAsync(CancellationToken.None);
        //credential = await GoogleWebAuthorizationBroker
        //    .AuthorizeAsync(
        //        stream,
        //        new[] { DriveService.Scope.DriveReadonly },
        //        userId,
        //        CancellationToken.None,
        //        new FileDataStore("oauth/drive"))
        //    ;
        //Console.WriteLine("Credential file saved");
    }
