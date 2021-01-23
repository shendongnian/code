            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YoutubeService.Scope.<THE_RIGHT_SCOPE_HERE> },
                    "user", CancellationToken.None);
            }
            // Create the service.
            _service = new YouTubeService(new BaseClientService.Initializer {
            ApplicationName = config.AppName,
                    HttpClientInitializer = credential,
                    ApplicationName = "Books API Sample",
                });
