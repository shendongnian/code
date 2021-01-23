         XmlDocument originalDoc = new XmlDocument();
            originalDoc.Load("c:\\data\\Orignal.xml");
            XmlNode exclusionNode = originalDoc.SelectSingleNode("/Document/ExlusionContainer");
           
            XmlDocument docToReplace = new XmlDocument();
            docToReplace.Load("c:\\data\\replace.xml");
            XmlNode replaceNode = docToReplace.SelectSingleNode("/ExclusionContainer");
            exclusionNode.InnerXml = replaceNode.InnerXml;
            originalDoc.Save("c:\\data\\orignal.xml");
