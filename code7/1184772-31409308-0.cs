    var xml = new XmlDocument();
    xml.LoadXml("...XML here...");
    XmlNodeList nodes = xml.SelectNodes("//Field/Value");
    foreach (XmlElement node in nodes)
    {
        node.InnerText = node.InnerText.Replace("'", "&apos;");
    }
    // Result
    Console.WriteLine(xml.OuterXml);
    // This is what other applications will get
    Console.WriteLine(xml.SelectSingleNode("//Field/Value/text()").Value);
    Console.ReadLine();
