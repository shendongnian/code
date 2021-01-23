    XmlDocument _doc = new XmlDocument();
    _doc.LoadXml("<price><Amount><Amount>100</Amount></Amount></price>");
    XmlDocument _newXmlDoc = new XmlDocument();
    XmlNode _rootNode = _newXmlDoc.CreateElement("price");
    _newXmlDoc.AppendChild(_rootNode);
    XmlNode _priceNode = _newXmlDoc.CreateElement("Amount");
    _priceNode.InnerText = _doc.LastChild.InnerText;
    _rootNode.AppendChild(_priceNode);
    Console.WriteLine(_newXmlDoc.OuterXml);
