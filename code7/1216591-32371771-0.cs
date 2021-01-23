    public List<string> HtmlAgilityPackGetHrefIfValueContains(string html, string href_text)
    {
        var hrefs = new List<string>();
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
        var nodes = hap.DocumentNode.SelectNodes("//*[@href]");
        if (nodes != null)
        {
           foreach (var node in nodes)
           {
               foreach (var attribute in node.Attributes)
                   if (attribute.Name == "href" && attribute.Value.Contains(href_text))
                   {
                       hrefs.Add(attribute.Value);
                   }
            }
        }
        return hrefs;
     }
