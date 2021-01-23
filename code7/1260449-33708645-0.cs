    public int HtmlAgilityPackCountAwithUnderscore(string html)
    {
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
        var nodes = hap.DocumentNode.SelectNodes("//a[contains(@href,'_')]");
        return nodes != null ? nodes.Count : -1;
    }
