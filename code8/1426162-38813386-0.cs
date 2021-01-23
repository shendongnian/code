    System.Xml.XmlDocument doc = new System.XmlDocument(); 
    //Loading the Xml document
      doc.load("YourXmlFileUrl.xml");
    
    //geting the Name nodes
    System.Xml.XmlNodeList nodes = doc.GetElementsByTagName("Name");
    //saving both names into String variables:
    String Name_01 = nodes[0].InnerXml;
    String Name_02 = nodes[1].InnerXml;
    
         
