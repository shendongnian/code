    static XDocument GetXml(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.GetStreamAsync(url);
            return XDocument.Load(response.Result);
        }
    }
