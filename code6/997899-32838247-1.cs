    ServiceAccountCredential credential = new ServiceAccountCredential(
      new ServiceAccountCredential.Initializer(ServiceAccount) {
        Scopes = new[] {DriveService.Scope.Drive,"https://spreadsheets.google.com/feeds"}
      }.FromCertificate(certificate)
    );
    bool success = credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Result;
    ....
    SpreadsheetsService spreadsheetsService = new SpreadsheetsService(applicationName);
    var requestFactory = new Google.GData.Client.GDataRequestFactory(applicationName);
      requestFactory.CustomHeaders.Add(string.Format("Authorization: Bearer {0}", credential.Token.AccessToken));
      spreadsheetsService.RequestFactory = requestFactory;
