    private List<string> GetTopmostDivs(string html)
    {
        var result = new List<KeyValuePair<string, string>>();
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
        var nodes = hap.DocumentNode.SelectNodes("//div[not(ancestor::div)]");
        if (nodes != null)
            return nodes.Select(p => p.OuterHtml).ToList();
        else
            return new List<string>();
    }
