            // Get legacy XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" +
                        "<test>I am a test</test>" +
                        "</root>");
            // Add its root element to the XDocument
            XDocument saveFile = new XDocument(
                new XElement("settings", xmlDoc.ToXElement()));
            // Save
            Debug.WriteLine(saveFile.ToString());
