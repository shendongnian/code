    public string getCleanHtml(string html)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        return HtmlAgilityPack.HtmlEntity.DeEntitize(doc.DocumentNode.InnerText);
    }
