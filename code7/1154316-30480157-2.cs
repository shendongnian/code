    using System.Security.Cryptography.X509Certificates;
    using Google.GData.Client;
    using Google.GData.Extensions;
    using Google.GData.Spreadsheets;
    using Google.Apis.Auth.OAuth2;
    string keyFilePath = @"C:\key.p12";    // found in developer console
    string serviceAccountEmail = "youraccount@developer.gserviceaccount.com";   // found in developer console
    var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
    ServiceAccountCredential credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail) //create credential using certificate
            {
                Scopes = new[] { "https://spreadsheets.google.com/feeds/" } //this scopr is for spreadsheets, check google scope FAQ for others
            }.FromCertificate(certificate));
    credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Wait(); //request token
    var requestFactory = new GDataRequestFactory("Some Name"); 
    requestFactory.CustomHeaders.Add(string.Format("Authorization: Bearer {0}", credential.Token.AccessToken));
    SpreadsheetsService myService = new SpreadsheetsService("You App Name"); //create your old service
    myService.RequestFactory = requestFactory; //add new request factory to your old service
    SpreadsheetQuery query = new SpreadsheetQuery(); //do the job as you done it before
    SpreadsheetFeed feed = myService.Query(query);
