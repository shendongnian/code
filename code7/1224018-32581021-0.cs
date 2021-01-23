    public string HtmlAgilityPackRemoveTagsWithSpecificAttribute(string html, string xpath, string attribute_name, Regex rx)
    {
        HtmlAgilityPack.HtmlDocument hap;
        Uri uriResult;
        if (Uri.TryCreate(html, UriKind.Absolute, out uriResult) &&
                                  uriResult.Scheme == Uri.UriSchemeHttp)
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
           {
               if (rx.IsMatch(node.Attributes[attribute_name].Value))
                   node.ParentNode.RemoveChild(node);
           }
        }
        return hap.DocumentNode.OuterHtml;
    }
