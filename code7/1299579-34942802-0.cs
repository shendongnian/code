    string[] scopes = new string[] { "onedrive.readwrite" };
    var client = OneDriveClientExtensions.GetUniversalClient(scopes) as OneDriveClient;
    await client.AuthenticateAsync();
    //get the access_token
    var AccessToken = client.AuthenticationProvider.CurrentAccountSession.AccessToken;
    //REST API to request info about the signed-in user
    var uri = new Uri($"https://apis.live.net/v5.0/me?access_token={AccessToken}");
    
    var httpClient = new System.Net.Http.HttpClient();
    var result = await httpClient.GetAsync(uri);
    //user info returnd as JSON
    string jsonUserInfo = await result.Content.ReadAsStringAsync();
    if (jsonUserInfo != null)
    {
        var json = Newtonsoft.Json.Linq.JObject.Parse(jsonUserInfo);
        string username = json["name"].ToString();
    }
