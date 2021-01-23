    [Route("value"), HttpPost]
    public HttpResponseMessage Post(HttpRequestMessage value)
    {
        var res = value.Content.ReadAsStringAsync().Result;
        return null;
    }
    HttpClient client = new HttpClient();
    var content = new StringContent("boe");
    var result = client.PostAsync(baseAddress + "api/value", content).Result;
