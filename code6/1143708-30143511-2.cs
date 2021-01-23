    var node = HtmlPage.DocumentNode.Descendants("h3").Where(h => h.Class == "Bar").FirstOrDefault();
    if (node != null)
    {
        var linkNode = node.Elements("a").FirstOrDefault();
        if (node != null)
        {
            string link = node.Attributes["href"].value : string.empty;
            string username = node.InnerText;
        }
    }
