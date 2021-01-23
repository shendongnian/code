    var xml = "<Names><Name type=\"M\" name=\"John\"></Name></Names>";
    var doc = new XmlDocument();
    doc.LoadXml(xml);
    
    var nodes = doc.DocumentElement.ChildNodes;
    foreach (XmlNode node in nodes)
    {
        Console.WriteLine(node.Name + " : " + node.Value);
        foreach (XmlAttribute attr in node.Attributes)
        {
            Console.WriteLine(attr.Name + " : " + attr.Value);
        }
    }
