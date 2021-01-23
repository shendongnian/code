    using (var client = new HttpClient() { BaseAddress = new Uri(@"https://thirdparty.com") })
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(...);
    
        var uri = new Uri(@"rest/api/foo", UriKind.Relative);
        var content = new StringContent(json.ToString());
    
        client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
        using (var response = await client.PostAsync(uri, content))
        {
            // etc ...
        }
    }
