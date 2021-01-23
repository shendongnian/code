    public List<string> HtmlAgilityPackGetTagOuterHTMLbyXpath(string html, string xpath)
    {
        HtmlAgilityPack.HtmlDocument hap;
        var results = new List<string>();
        Uri uriResult;
        if (Uri.TryCreate(html, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
        { // html is a URL 
            var doc = new HtmlAgilityPack.HtmlWeb();
            hap = doc.Load(uriResult.AbsoluteUri);
        }
        else
        { // html is a string
            hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(html);
        }
        var nodes = hap.DocumentNode.SelectNodes(xpath);
        if (nodes != null)
        {
           foreach (var node in nodes)
               results.Add(node.OuterHtml);
        }
        return results;
    }
