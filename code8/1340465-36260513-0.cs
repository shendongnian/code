    public static async Task<UserCredentials> Login(string username, string password)
    {
        string baseAddress = "127.0.0.1/";
        HttpClient client = new HttpClient();
    
        var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("xyz:secretKey"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);
    
    
    
        var form = new Dictionary<string, string>
        {
            { "grant_type", "password" },
            { "username", username },
            { "password", password },
        };
    
        var Response = await client.PostAsync(baseAddress + "oauth/token", new FormUrlEncodedContent(form));
        if (Response.StatusCode == HttpStatusCode.OK)
        {
            return await Response.Content.ReadAsAsync<UserCredentials>(new[] { new JsonMediaTypeFormatter() });
        }
        else
        {
            return null;
        }
    }
