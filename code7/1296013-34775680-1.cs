    XmlDocument xmlDoc = new XmlDocument();
    XmlNamespaceManager namespaces = new XmlNamespaceManager(xmlDoc.NameTable);
    namespaces.AddNamespace("ns", "http://ws.cdyne.com/");
    xmlDoc.Load(response.GetResponseStream());
    XmlNode msgnode = xmlDoc.DocumentElement.SelectSingleNode("/ns:IPInformation/ns:Country",namespaces);
    string msgname = msgnode.InnerText;
