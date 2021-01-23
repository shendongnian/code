    using(var handler = new System.Net.Http.HttpClientHandler())
    { 
        using(var client = new System.Net.Http.HttpClient(handler))
        {
           using(var resp = (await client.GetAsync("any url")))
           {
                var content = resp.Content;
           }
        }
    }
