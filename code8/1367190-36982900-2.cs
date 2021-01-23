    string s = "<Node a=\"<b>\">";
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(s);
    var node = doc.DocumentNode.FirstChild;
    var attr = node.Attributes[0];
    using (var writer = XmlWriter.Create(Console.Out))
    {
        writer.WriteStartElement(node.Name);
        writer.WriteAttributeString(attr.Name, attr.Value);
    }
