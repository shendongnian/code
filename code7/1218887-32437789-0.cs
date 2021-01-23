    var xml = new XmlDocument();
    xml.Load(new StreamReader(xml));
    foreach (XmlNode x1 in xml.GetElementsByTagName("Adapter"))
    {
        Console.WriteLine(x1.Attributes["Name"].Name + "::" + x1.Attributes["Name"].Value);
    }
    var p = xml.GetElementsByTagName("Monitors");
    foreach (XmlNode x in p)
    {
        foreach (XmlElement e in x)
        {
            Console.WriteLine(e.Attributes["ConnectorIndex"].Name + "::" + e.Attributes["ConnectorIndex"].Value);
            Console.WriteLine(e.Attributes["ViewType"].Name + "::" + e.Attributes["ViewType"].Value);
        }
    }
