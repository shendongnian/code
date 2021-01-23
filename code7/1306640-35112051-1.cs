    public List<docs> parsexml(string url, string siteType)
    {
        var docsList = new List<docs>();
        using (var client = new WebClient())
        using (var stream = client.OpenRead (url)) 
        {
            var doc = XDocument.Load(stream);
            XNamespace nameSpace = "/response/result/";
            var xmlProducts = doc.Descendants(nameSpace + "docs");
    ...
