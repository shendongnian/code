    var doc = new XDocument(
        new XElement("parent",
            new XElement("child", 1)));
    
    var parent = doc.Descendants("parent").Single();
    
    var duplicateChild = new XElement("child", 1);
    var newChild = new XElement("child", 2);
    
    if (!parent.Elements().Any(e => XNode.DeepEquals(e, duplicateChild)))
    {
        parent.Add(duplicateChild);
    }
    
    if (!parent.Elements().Any(e => XNode.DeepEquals(e, newChild)))
    {
        parent.Add(newChild);
    }
