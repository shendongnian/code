            XmlDocument xmlText = new XmlDocument();
            xmlText.Load(yourXml);
            XmlElement root = xmlText.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlText.NameTable);
            nsmgr.AddNamespace("t", "http://www.ebay.com/marketplace/search/v1/services");
            XmlNodeList xnList = xmlText.SelectNodes("//t:item", nsmgr);
            foreach (XmlNode item in xnList)
            {
                string title = item["title"].InnerText;
                Console.WriteLine(title);
            }
