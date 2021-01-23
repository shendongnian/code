    public static async Task Test()
    {
        var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(@"https://google.ca");
        string responseUrl = response.RequestMessage.RequestUri.ToString();
    }
