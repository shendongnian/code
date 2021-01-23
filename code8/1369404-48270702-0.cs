    using (var content = new MultipartFormDataContent())
    {
        foreach (var keyValuePair in data)
        {
            content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
        }
    
        // send POST request
        using (var client = new HttpClient())
        {
            return client.PostAsync(identifier.IsirUrl + uri, content).GetAwaiter().GetResult();
        }
    }
