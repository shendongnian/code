    public IEnumerable<string> GetFileUrls(string url)
    {
        var document = new HtmlWeb().Load(url);
        var urls = document.DocumentNode.Descendants("img")
                                        .Select(e => e.GetAttributeValue("src", null))
                                        .Where(s => s.ToLower().StartsWith("http://www.example.com/"));
    
        return urls;
    }
