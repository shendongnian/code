    private List<KeyValuePair<string, string>> GetLinksWithHtmlAgilityPack(string html)
    {
        var result = new List<KeyValuePair<string, string>>();
        var hap = new HtmlAgilityPack.HtmlDocument();
        hap.LoadHtml(html);
        // Or, if you pass a URL, you can comment the 2 lines above and uncomment the two lines below
        // var doc = new HtmlAgilityPack.HtmlWeb();
        // var hap = doc.Load(html);
        var nodes = hap.DocumentNode.SelectNodes("//a");
        if (nodes != null)
           foreach (var node in nodes)
               if (Path.GetExtension(node.InnerText.Trim()).ToLower() == ".png" ||
                   Path.GetExtension(node.InnerText.Trim()).ToLower() == ".jpg")
                   result.Add(new KeyValuePair<string,string>(node.GetAttributeValue("href", null), node.InnerText));
        return result;
    }
