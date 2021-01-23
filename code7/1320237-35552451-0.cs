    using System.Xml;
                .
                .
                .
                XmlDocument doc = new XmlDocument();
                doc.Load("source.xml");
                // if you have the xml in a string use doc.LoadXml(stringvar)
                XmlNamespaceManager nsmngr = new XmlNamespaceManager(doc.NameTable);
                XmlNodeList results = doc.DocumentElement.SelectNodes("child::Employee", nsmngr);
                foreach (XmlNode result in results)
                {
                    XmlNode namenode = result.SelectSingleNode("Address");
                    XmlNodeList types = result.SelectNodes("line");
                    foreach (XmlNode type in types)
                    {
                        Console.WriteLine(type.InnerText);
                    }
                    XmlNode fmtaddress = result.SelectSingleNode("formatted_address");
                }
