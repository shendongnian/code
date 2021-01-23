    private List<string> getListingsFromXML(string fileName)
        {
            List<string> returnList = new List<string>();
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ebay", "urn:ebay:apis:eBLBaseComponents");
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//ebay:ActiveInventoryReport", ns);
            XmlNodeList skus = node.SelectNodes("//ebay:SKUDetails", ns);
            foreach (XmlNode sku in skus)
            {
                XmlNode tempNode = sku.SelectSingleNode("ebay:SKU", ns);
                if (tempNode != null)
                {
                    returnList.Add(tempNode.InnerText.Trim());
                }
            }
            return returnList;
        }
