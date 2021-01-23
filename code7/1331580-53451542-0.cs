    using Newtonsoft.Json;
    ...
    
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.clickatell.com/rest/message"),
                Headers = { 
                    { HttpRequestHeader.Authorization.ToString(), "Bearer xxxxxxxxxxxxxxxxxxxx" },
                    { HttpRequestHeader.Access.ToString(), "application/json" },
                    { "X-Version", "1" }
                },
                Content = new StringContent(JsonConvert.SerializeObject(svm))
            };
        var response = client.SendAsync(httpRequestMessage).Result;
    
