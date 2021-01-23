        // These come from the APIs console:
        //   https://code.google.com/apis/console
        public static ClientSecrets secrets = new ClientSecrets()
        {
            ClientId = "YOUR_CLIENT_ID",
            ClientSecret = "YOUR_CLIENT_SECRET"
        };
...
            UserCredential credential;
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = secrets,
                Scopes = new[] { PlusService.Scope.PlusLogin}
            };
            var flow = new AAGoogleAuthorizationCodeFlow(initializer);
            credential = await new AuthorizationCodeInstalledApp(flow, new LocalServerCodeReceiver()).AuthorizeAsync
                ("user", CancellationToken.None).ConfigureAwait(false);
            // Create the service.
            var service = new PlusService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gus API",
                });
