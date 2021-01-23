     XNamespace testNM = "urn:lst-emp:emp";
                XDocument xDoc;
                string path = "project_data.xml";
                if (!File.Exists(path))
                {
                    xDoc = new XDocument(
                               new XDeclaration("1.0", "UTF-16", null),
                               new XElement(XName.Get("Tests", testNM.NamespaceName))
                               );
                }
                else
                {
                    xDoc = XDocument.Load(path);
                }
                var element = new XElement(XName.Get("key", testNM.NamespaceName),
                                        new XAttribute("name", "someString"),
                                        new XElement("Type", type),
                                        new XElement("Value", value));
                xDoc.Element(XName.Get("Tests", testNM.NamespaceName)).Add(element);
                // Save to Disk
                xDoc.Save(path);
