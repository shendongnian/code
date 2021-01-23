    string requestJson = JsonConvert.SerializeObject(request, 
        Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    
    
    
    using (var httpClient = new HttpClient())
    {
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var response = httpClient.PostAsync(url, content).Result;
        var res = response.Content.ReadAsStringAsync().Result;
    }
