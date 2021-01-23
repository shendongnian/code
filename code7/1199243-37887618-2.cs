    GoogleCredential credential;
    using (Stream stream = new FileStream(@"C:\mykey.json", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        credential = GoogleCredential.FromStream(stream);
    }
    string[] scopes = new string[] {
        BigqueryService.Scope.Bigquery,
        BigqueryService.Scope.CloudPlatform, 
    };
    credential = credential.CreateScoped(scopes);
    BaseClientService.Initializer initializer = new BaseClientService.Initializer()
    {
        HttpClientInitializer = (IConfigurableHttpClientInitializer)credential,
        ApplicationName = "My Application",
        GZipEnabled = true,
    };
    BigqueryService service = new BigqueryService(initializer);
