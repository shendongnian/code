    XmlDocument doc = new XmlDocument();
    doc.Load("yourfile.xml");
    XmlNodeList usernodes = doc.SelectNodes("//property");
    //Declare arrays
    List<string> serviceName = new List<string>();
    List<string> servicePath = new List<string>();
    //iterate through all elements found
    foreach (XmlNode usernode in usernodes)
    {
	    serviceName.Add(usernode.Attributes["name"].Value);
    	serviceName.Add(usernode.Attributes["value"].Value);
    }
