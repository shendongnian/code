    XDocument doc = XDocument.Load("xmlfile.xml");
    // Remove RefSource tags.
    foreach (var node in doc.Descendants("RefSource").ToList())
    {
        node.Parent.ReplaceAll(node.Value);
        // or
        //node.ReplaceWith(node.Value);
    }
    // Change Emphasis tags to i tags.
    foreach (var node in doc.Descendants("Emphasis").ToList())
    {
        node.ReplaceWith(new XElement("i", node.Value));
    }
    doc.Save("xmlfile2.xml");
