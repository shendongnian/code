    Dictionary<int, string> myDictionary = new Dictionary<int, string>();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(<myInputXMLAsString>);
                XmlNodeList xnList = xml.SelectNodes("/Run/Roles");
    
                foreach (XmlNode xn in xnList)
                {
                    int roleId = int.Parse(xn["Role"].Attributes["id"].Value);
                    XmlDocument subXmlDocument = new XmlDocument();
                    subXmlDocument.LoadXml(xn.InnerXml);
                    XmlNodeList subXn = subXmlDocument.SelectNodes("/Role/ValidationInformation");
                    string validationInfo = subXn[0].InnerXml;
                    roleIdToValidationInformationDictionary.Add(roleId, validationInfo);
                }
