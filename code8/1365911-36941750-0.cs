    // app entry point - the only place you should block
    void Main()
    {
        MainAsync().Wait();
    }
    // the "real" starting point of your app logic. do everything async from here on
    async Task MainAsync()
    {
        ...
        var token = await GetApiTokenAsync(username, password, apiBaseUri);
        ...
    }
    async Task<string> GetApiTokenAsync(string username, string password, string apiBaseUri)
    {
        var token = string.Empty;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiBaseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(60);  
            //setup login data
            var formContent = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("grant_type", "password"),
             new KeyValuePair<string, string>("username", username),
             new KeyValuePair<string, string>("password", password),
             });
            //send request               
            HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(responseJson);
            token = jObject.GetValue("access_token").ToString();
            return token;
        }
    }
