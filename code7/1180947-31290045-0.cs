    using System.Xml.XPath;
    using System.Xml.Linq;
    
    XDocument xdoc1 = XDocument.Load("xml1.xml");
    XDocument xdoc2 = XDocument.Load("xml2.xml");
    string sku = String.Empty;
    string searchedID = "2";
    
    //1.searching through an xml file based on path
    foreach (XElement message in xdoc1.XPathSelectElements("Envelope/Message"))
    {
    	if (message.Element("MessageID").Value.Equals(searchedID))
    	{
    		//2.grabbing another node's details
    		sku = message.XPathSelectElement("Inventory/SKU").Value;
    	}
    }
    foreach (XElement message in xdoc2.XPathSelectElements("Envelope/Message"))
    {
    	if (message.XPathSelectElement("Inventory/SKU") != null && message.XPathSelectElement("Inventory/SKU").Value.Equals(sku))
    	{
    		//removing a node
    		message.Remove();
    	}
    }
    xdoc2.Save("xml2_del.xml");
    }
