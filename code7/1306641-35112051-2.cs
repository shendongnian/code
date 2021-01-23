    public List<docs> parsexml(string url, string siteType)
    {
        var docsList = new List<docs>();
        var doc = XDocument.Load(url);
        XNamespace nameSpace = "/response/result/";
        var xmlProducts = doc.Descendants(nameSpace + "docs");
    ...
