    public string getCleanHtml(string html)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        // return HtmlAgilityPack.HtmlEntity.DeEntitize(doc.DocumentNode.InnerText); // Use if you want to convert HTML entities to their literal view
        return doc.DocumentNode.InnerText; // if you want to keep HTML entities
    }
