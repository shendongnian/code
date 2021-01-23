    var xmlDoc = new XmlDocument();
    xmlDoc.Load(fileLocation);
    //determine  whether document contains namespace
    var namespaceName = "ns";
    var namespacePrefix = string.Empty;
    XmlNamespaceManager nameSpaceManager = null;
    if (xmlDoc.FirstChild.Attributes != null)
    {
        var xmlns = xmlDoc.FirstChild.Attributes["xmlns"];
        if (xmlns != null)
        {
              nameSpaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
              nameSpaceManager.AddNamespace(namespaceName, xmlns.Value);
              namespacePrefix = namespaceName + ":";
        }
    }
        
    XmlNodeList nodeList = xmlDoc.SelectNodes(string.Format("/{0}Demo/{0}Items",namespacePrefix), nameSpaceManager);
    if (nodeList != null)
    {
        foreach (XmlNode childNode in nodeList)
        {
           string first = childNode.SelectSingleNode(namespacePrefix + "First", nameSpaceManager).InnerText;
           string second = childNode.SelectSingleNode(namespacePrefix + "Second", nameSpaceManager).InnerText;
           string third = childNode.SelectSingleNode(namespacePrefix +  "Third", nameSpaceManager).InnerText;
         }
     }
