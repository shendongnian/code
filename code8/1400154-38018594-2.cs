    private static string API_BASE_URL = "https://<CRM DOMAIN>.com/";
    private static string API_URL = "https://<CRM DOMAIN>.com/api/data/v8.1/";
    private static string CLIENT_ID = "<CLIENT ID>";
    
    static void Main(string[] args)
    {
        var ap = AuthenticationParameters.CreateFromResourceUrlAsync(
                    new Uri(API_URL)).Result;
                
        var authContext = new AuthenticationContext(ap.Authority, false);
    
        var userCredential = new UserCredential("<USERNAME>", "<PASSWORD>");
    
        var result = authContext.AcquireToken(API_BASE_URL, CLIENT_ID, userCredential);
    
        var httpClient = HttpWebRequest.CreateHttp(Path.Combine(API_URL, "accounts"));
        httpClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer:" + result.AccessToken);
        using (var sr = new StreamReader(httpClient.GetResponse().GetResponseStream()))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
