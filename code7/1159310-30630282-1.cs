    /// <summary>
    /// Collects a href attribute values and a node values if image extension is jpg or png
    /// </summary>
    /// <param name="html">HTML string or an URL</param>
    /// <returns>A key-value pair list of href values and a node values</returns>
    private List<KeyValuePair<string, string>> GetLinksWithHtmlAgilityPack(string html)
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
        var nodes = hap.DocumentNode.SelectNodes("//a");
        if (nodes != null)
            foreach (var node in nodes)
                if (Path.GetExtension(node.InnerText.Trim()).ToLower() == ".png" ||
                        Path.GetExtension(node.InnerText.Trim()).ToLower() == ".jpg")
                result.Add(new KeyValuePair<string,string>(node.GetAttributeValue("href", null), node.InnerText));
        return result;
    }
