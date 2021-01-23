    private static DriveService Service()
    {
        var certificate = new X509Certificate2(Constants.P12, "notasecret",X509KeyStorageFlags.Exportable);
        var credential = new ServiceAccountCredential(
           new ServiceAccountCredential.Initializer(Constants.ServiceAccountEmail)
           {
               Scopes = new[] {DriveService.Scope.Drive},
               User="someuser@somedomain.someextension" //Add this to your code!
           }.FromCertificate(certificate));
        // Create the service.
        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "MyApplicationName",
        });
        return service;
    }
