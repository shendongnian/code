    using (WebClient client = new WebClient())
    {
        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        client.Headers.Add(HttpRequestHeader.Accept, "application/json");
        client.UploadDataAsync(new Uri(apiUrl), "POST", Encoding.UTF8.GetBytes(jsonString));
    }
