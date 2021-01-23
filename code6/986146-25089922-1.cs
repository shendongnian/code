    public async Task RequestAndDeserializeJson()
    {
        var httpClient = new HttpClient();
        var json = await httpClient.GetAsStringAsync("http://3rdPartySite.com");
        RootObject obj = JsonConvert.Deserialize<RootObject>(json);
    }
