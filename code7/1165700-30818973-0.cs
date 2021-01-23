    var doc = XDocument.Parse(xml);
    var existingDeclarations = doc.Descendants()
        .SelectMany(e => e.Attributes().Where(a => a.IsNamespaceDeclaration))
        .ToList();
    doc.Root.Add(new XAttribute(XNamespace.Xmlns + "p", "http://example.com/schema2"));
    existingDeclarations.Remove();
