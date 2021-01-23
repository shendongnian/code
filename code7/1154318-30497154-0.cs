        const string ServiceAccountEmail = "452351479-q41ce1720qd9l94s8847mhc0toao1fed@developer.gserviceaccount.com";
        var certificate = new X509Certificate2(@"Key.p12", "notasecret", X509KeyStorageFlags.Exportable);
        var serviceAccountCredentialInitializer = 
            new ServiceAccountCredential.Initializer(ServiceAccountEmail)
            {
                Scopes = new[] { "https://spreadsheets.google.com/feeds" }
            }.FromCertificate(certificate);
        var credential = new ServiceAccountCredential(serviceAccountCredentialInitializer);
        if (!credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Result)
            throw new InvalidOperationException("Access token request failed.");
        var requestFactory = new GDataRequestFactory(null);
        requestFactory.CustomHeaders.Add("Authorization: Bearer " + credential.Token.AccessToken);
        var service = new SpreadsheetsService(null) { RequestFactory = requestFactory };
        var query = new ListQuery("https://spreadsheets.google.com/feeds/list/0ApZkobM61WIrdGRYshh345523VNsLWc/1/private/full");
        var feed = service.Query(query);
        var rows = feed.Entries
            .Cast<ListEntry>()
            .Select(arg =>
                new
                {
                    Field0 = arg.Elements[0].Value,
                    Field1 = arg.Elements[1].Value
                })
            .ToList();
