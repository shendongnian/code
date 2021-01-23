    XmlDocument xml = new XmlDocument();
    xml.Load(@"C:\file.xml");
    //create a namespace manager for the SOAP Namespace
    XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
    ns.AddNamespace("SOAP", "http://schemas.xmlsoap.org/soap/envelope/");
    
    //create a new node
    XmlNode newNode = xml.CreateNode(XmlNodeType.Text, "John", "");
    
    //get the elements where do you want to add the new node
    XmlNode testedObject = xml.SelectSingleNode("//sas.Test.adhocExecuteAndWait[@*]/testedObject", ns);
    
    XmlNode lspNode = parent.SelectSingleNode("//sas.Test.adhocExecuteAndWait[@*]/test/lsp", ns);
    
    //add the new node
    testedObject.AppendChild(newNode);
    lspNode.AppendChild(newNode);
