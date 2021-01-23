    using (var client = Connector.GetHttpClient())
    {
        var response = await client.GetByteArrayAsync(url);
        data = Encoding.UTF8.GetString(response);
    }
