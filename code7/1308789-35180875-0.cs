    xDoc1 = new XmlDocument();
    xDoc1.Load("file.xml"); // Containing the given example above.
    
    XmlNodeList nodes = xDoc1.SelectSingleNodes("//bbb[@id='1']");
    
    foreach (XmlNode n in nodes)
    {
        XmlNode parent = n.ParentNode;
        parent.RemoveChild(n);
        Console.WriteLine(n.OuterXml);
    }
