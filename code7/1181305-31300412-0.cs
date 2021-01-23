    try
    {
        HttpResponseMessage response = await client.GetAsync("api/products/1");
        resp.EnsureSuccessStatusCode();    // Throw if not a success code.
    
        // ...
    }
    catch (HttpRequestException e)
    {
        // Handle exception.
    }
