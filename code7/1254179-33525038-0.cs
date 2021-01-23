    // Create an HTML Document to parse
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    // Load in the third party control's HTML output
    doc.LoadHtml(htmlEditor1.Html);
    // Retrieve the paragraph (p) nodes of the document
    List<HtmlAgilityPack.HtmlNode> paragraphNodes = doc.DocumentNode.DescendantNodes()
        .Where(node => node.Name == "p")
        .ToList();
    
    // Process each of the paragraph nodes in turn
    foreach (var node in paragraphNodes)
    {
        // Output the paragraph text
        // TODO: save the text in the database...
        Console.WriteLine(node.InnerText);
    }
