                    XmlNamespaceManager NamespaceManager = new XmlNamespaceManager(new NameTable());
                NamespaceManager.AddNamespace("base", "http://testserver.windows.net/");
                NamespaceManager.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices");
                NamespaceManager.AddNamespace("m", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
                NamespaceManager.AddNamespace("ns", "http://www.w3.org/2005/Atom"); XDocument doc = XDocument.Parse(XElement);
            var properties = doc.XPathSelectElement("/ns:entry/ns:content/m:properties", NamespaceManager);
