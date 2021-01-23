    public static string GetJsonData()
    {
        var promise = GetWebStringAsync("https://api.myjson.com/bins/2hxei");
        // do something else if needed
        var jsonData = promise.Result;
        return jsonData; //{"A":"Z","B":{"C":"Y","D":"X"}}
    }
    public static async Task<string> GetWebStringAsync(string uri)
    {
        using (var client = new HttpClient())
        {
            var stringTask = await client.GetStringAsync(uri);
            return stringTask;
        }
    }
