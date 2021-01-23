     xmlDOM.LoadXml(p_strXmlDocument);
     XmlElement root = xmlDOM.DocumentElement;
    
     XmlNamespaceManager NameSpaceManager = new XmlNamespaceManager(new NameTable());
     NameSpaceManager.AddNamespace("mgns1", "http://www.hidden.com/");
    
     XmlNodeList nodeList = xmlDOM.SelectNodes("//mgns1:xmlDocument/*", NameSpaceManager);
     string returnStr = "";
     if (nodeList != null)
     {
          foreach (XmlNode node in nodeList)
          {
                returnStr += node.OuterXml;
          }
     }
