    public ActionResult Dashboard()
    {
        ViewBag.Message = "Dashboard.";
        var scopes = new string[]
        {
            AnalyticsService.Scope.Analytics, // view and manage your Google Analytics data
            AnalyticsService.Scope.AnalyticsReadonly,
            AnalyticsService.Scope.AnalyticsEdit
        };
        const string serviceAccountEmail = "526261635050-fofbfeicvbpgumafa114te878787878@developer.gserviceaccount.com";  
        const string keyFilePath = @"D:\key.p12";
        var certificate = new X509Certificate2(certificateFile, "notasecret", X509KeyStorageFlags.Exportable);
        var serviceAccountCredential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
        {
            Scopes = scope
        }.FromCertificate(certificate));
        Task<string> task = ((ITokenAccess)serviceAccountCredential).GetAccessTokenForRequestAsync();
        task.Wait();
        var _accessToken = task.Result;
        ViewBag.Token = _accessToken;
        return View();
    }
