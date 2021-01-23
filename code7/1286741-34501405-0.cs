    var filter = new HttpBaseProtocolFilter();
    // Disable cache of responses.
    filter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
    // Pass filter to HttpClient constructor.
    var client = new HttpClient(filter);
    var response = await client.GetAsync(new Uri("http://example.com"));
    var responseString = await response.Content.ReadAsStringAsync();
