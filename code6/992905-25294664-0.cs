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
                    HttpClientInitializer = credential
                });
