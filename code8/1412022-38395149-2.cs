    XDocument doc = XDocument.Load("xmlfile.xml");
    // Remove RefSource tags.
    foreach (var node in doc.Descendants("RefSource").ToList())
    {
        node.ReplaceWith(node.Value);
    }
    // Remove OrgAddress tags.
    foreach (var node in doc.Root.Descendants().ToList())
    {
        if (node.HasElements)
        {
            node.ReplaceWith(node.Elements());
        }
    }
    // Change Emphasis tags to i tags.
    foreach (var node in doc.Descendants("Emphasis").ToList())
    {
        node.ReplaceWith(new XElement("i", node.Value));
    }
    doc.Save("xmlfile2.xml");
