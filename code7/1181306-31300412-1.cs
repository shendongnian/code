    try
    {
        HttpResponseMessage response = await client.GetAsync("api/products/1");
        response.EnsureSuccessStatusCode();    // Throw if not a success code.
    
        // ...
    }
    catch (HttpRequestException e)
    {
        // Handle exception.
    }
