    private async void GetMsaTokenAsync(WebAccountProviderCommand command)
    {
        WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
        WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
    
        if (result.ResponseStatus == WebTokenRequestStatus.Success)
        {
            string token = result.ResponseData[0].Token; 
    
            var restApi = new Uri(@"https://apis.live.net/v5.0/me?access_token=" + token);
    
            using (var client = new HttpClient())
            {
                var infoResult = await client.GetAsync(restApi);
                string content = await infoResult.Content.ReadAsStringAsync();
    
                var jsonObject = JsonObject.Parse(content);
                
                string username = jsonObject["name"].GetString();
            }
        }
    }
