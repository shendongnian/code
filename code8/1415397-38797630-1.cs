    var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = yourclientid,
                        ClientSecret = yourclientsecret
                    },
                    Scopes = new[] { CalendarService.Scope.Calendar }
                });
    
    
    
                var credential = new UserCredential(flow, Environment.UserName, new TokenResponse
                {
                    AccessToken = token.access_token,
                    RefreshToken = userrefreshtoke
                });
    
    
                CalendarService service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "application name",
                });
                var list = service.CalendarList.List().Execute().Items;
                foreach (var c in list)
                {
                    var events = service.Events.List(c.Id).Execute().Items.Where(i => i.Start.DateTime >= DateTime.Now).ToList();
                    foreach (var e in events)
                    {
                    }
    }
