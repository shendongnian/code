    public string joinCleanNodeValues(string html, string separator)
    {
        var doc = new HtmlAgilityPack.HtmlDocument(); // Load the HTML 
        doc.LoadHtml(html);                           // Build the DOM
        var nodes = doc.DocumentNode.ChildNodes       // Go thtough the nodes
            .Select(p => HtmlAgilityPack.HtmlEntity.DeEntitize(p.InnerText))
            .ToList(); // Collect inner texts with all entities converted to literal texts
        return string.Join(separator, nodes);         // Return the joined node values
    }
