    var loginData = new { grant_type = "password", username = name, password = pass };
    HttpClient httpClient = new HttpClient();
    try
    {
        string resourceAddress = "http://localhost:24721/Token";
        string postBody = Newtonsoft.Json.JsonConvert.SerializeObjectloginData);
        var content = new StringContent(postBody, Encoding.UTF8, "application/json");
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage wcfResponse = await httpClient.PostAsync(resourceAddress, content);
    }
