    private List<string> GetTextFromHtmlTag(string html, string tag)
    {
       var result = new List<string>();
       HtmlAgilityPack.HtmlDocument hap;
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
       var nodes = hap.DocumentNode.ChildNodes.Where(p => p.Name.ToLower() == tag.ToLower() && p.GetAttributeValue("class", string.Empty) == "previous"); // SelectNodes("//"+tag);
        if (nodes != null)
            foreach (var node in nodes)
               result.Add(HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText));
        return result;
    }
