    public static async Task SendRequest(int port, string path, KVPairs kvPairs)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(BASE_ADDRESS + port);
            var request = new HttpRequestMessage(HttpMethod.Put, path);
            request.Content = new FormUrlEncodedContent(kvPairs);
            await ProcessResponse(await client.SendAsync(request)); // added await here
        }
    }
    public static async void ProcessResponse (HttpResponseMessage response) // added async here
    {
        Console.WriteLine(await response.Content.ReadAsStringAsync()); // added await here
    }
