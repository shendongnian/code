    public async Task GetTokenAsync(string tenant, string clientId, string clientSecret, string username, string password)
    {
        HttpResponseMessage resp;
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var req = new HttpRequestMessage(HttpMethod.Post, $"https://login.microsoftonline.com/{tenant}/oauth2/token/");
             req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
             {
                {"grant_type", "password"},
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"resource", "https://graph.microsoft.com"},
                {"username", username},
                {"password", password}
             });
             resp = await httpClient.SendAsync(req);
             string content = await resp.Content.ReadAsStringAsync();
             var jsonObj = new JavaScriptSerializer().Deserialize<dynamic>(content);               
             string token = jsonObj["access_token"];                
             Console.WriteLine(token);
        }
    }
