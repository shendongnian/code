    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.InnerXml = "<response><content><Result xmlns=\"http://www.test.com/nav/webservices/types\"><Name>Test</Name></Result></content><status>ok</status>";
    string elementValue = String.Empty;
    
    if (xmlDoc != null)
    {
    	xNode = xmlDoc.SelectSingleNode("/Result");
    	xNodeList = xNode.ChildNodes;
    	foreach (XmlNode node in xNodeList)
    	{
    		elementValue = node.InnerText;
    	}
    }
