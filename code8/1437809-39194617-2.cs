    string baseAddress = "http://localhost/";
    var client = new HttpClient();
    // you can pass the values in Authorization header or as form data
    //var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("clientId:secretKey"));
    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);
    var form = new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", "clientId"},
            {"client_secret", "secretKey"},
        };
    var tokenResponse = client.PostAsync(baseAddress + "accesstoken", new FormUrlEncodedContent(form)).Result;
    var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
    var authorizedResponse = client.GetAsync(baseAddress + "/api/Tests").Result;
