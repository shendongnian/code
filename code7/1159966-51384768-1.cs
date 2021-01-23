    string path = HostingEnvironment.MapPath("~/App_Data");    
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                             new ClientSecrets
                             {
                                 ClientId = "Client_ID",
                                 ClientSecret = "Secret_Client"
                             },
                             Scopes,
                             "me",
                             CancellationToken.None,
                             new FileDataStore(path)
    
                             ).Result;
