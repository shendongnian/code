        XmlDocument oXmlDocument = new XmlDocument();
        oXmlDocument.AppendChild(oXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", ""));
        string sFileContents = "XML Fragments In Here";
        XmlNode oRootXmlNode = oXmlDocument.CreateElement("Root");
        oRootXmlNode.InnerXml = sFileContents;
        oXmlDocument.AppendChild(oRootXmlNode);
        oXmlDocument.Save("XMLFileName.xml");
