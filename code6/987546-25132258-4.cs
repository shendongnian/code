    var xml = "http://itunes.apple.com/us/rss/topsongs/limit=10/genre=2/xml";
    
    XmlDocument doc = new XmlDocument();
    doc.Load(xml);
    var namespaceManager = new XmlNamespaceManager(doc.NameTable);
    namespaceManager.AddNamespace("itunes", "http://www.w3.org/2005/Atom");
    namespaceManager.AddNamespace("im", "http://itunes.apple.com/rss");
    
    XmlNodeList items = doc.SelectNodes("//itunes:entry", namespaceManager);
    foreach (XmlNode item in items)
    {
        var price = item.SelectSingleNode("//im:price", namespaceManager);
        var releaseDate = item.SelectSingleNode("//im:releaseDate", namespaceManager);
    
        if (price != null)
        {
            Console.WriteLine(price.Attributes["amount"].InnerText);
        }
    
        if (releaseDate != null)
        {
            Console.WriteLine(releaseDate.Attributes["label"].InnerText);
        }
    }
