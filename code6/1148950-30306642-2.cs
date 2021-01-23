    string result;
    using (var httpClient = new HttpClient())
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        var response = await httpClient.SendAsync(request);
        result = response.Content.ReadAsStringAsync().Result;
    }
    
    XmlReader rssFeed = XmlReader.Create(new StringReader(result));
