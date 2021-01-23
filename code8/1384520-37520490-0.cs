      UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore("Daimto.YouTube.Auth.Store")).Result;
