    using (var client = new HttpClient())
    {
        var response = await client.PostAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            //...
        }
    }
