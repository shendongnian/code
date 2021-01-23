    public static async PostToServer(string name)
    {
        var values = new Dictionary<string, string>
                                    {
                                       { "name", name},
                                       { "id", "1" }
                                    };
        HttpClient client = new HttpClient();
        var content = new FormUrlEncodedContent(values);
        HttpResponseMessage response = await client.PostAsync(new Uri("https://www.inventor-s-hub.xyz:8000/v8"), content );
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
