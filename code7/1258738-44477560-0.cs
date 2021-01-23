    public async Task Send(string userId, string devicePushToken, string content)
    {
    
        string json = JsonConvert.SerializeObject(new
        {
            tokens = new[] {devicePushToken},
            profile = "yourprofile",
            notification = new
            {
                message = content
            }
        });
    
        var restClient = new RestClient("https://api.ionic.io/");
        var restRequest = new RestRequest("push/notifications", Method.POST);
        restRequest.AddHeader("Accept", "application/json");
    
        restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
        restRequest.AddParameter("Authorization",
            "Bearer APIKEY",
            ParameterType.HttpHeader);
    
        await restClient.ExecuteTaskAsync(restRequest);
    }
