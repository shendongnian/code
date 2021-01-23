    ......
    var nsManager = new XmlNamespaceManager(new NameTable());
    //register mapping of prefix to namespace uri 
    nsManager.AddNamespace("gml", "http://www.opengis.net/gml");
    //pass the namespace manager instance as 2nd param of SelectNodes():
    XmlNodeList xnList = xml.SelectNodes("HostipLookupResultSet/gml:featureMember/Hostip", nsManager);
    ......
