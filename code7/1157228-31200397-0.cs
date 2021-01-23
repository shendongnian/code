      public void AddItemToRule(string inFile, string outFile, string ruleId, string itemVal)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(inFile); // loads xml file
                if (AddItemToRule(xmlDoc, ruleId, item))
                {
                    xmlDoc.Save(outFile);
                    MessageBox.Show(@"Inserted Successfully");
                }
            }
    
            public bool AddItemToRule(XmlDocument xmlDoc, string ruleId, string itemVal)
            {
                string ns = "http://www.w3.org/2001/06/grammar";
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsMgr.AddNamespace("g", ns);
                System.Diagnostics.Debug.WriteLine(nsMgr.DefaultNamespace);
                XmlNode foundNode = xmlDoc.SelectSingleNode("//g:rule[@id='" + ruleId + "']/g:one-of", nsMgr);
                if (foundNode != null)
                {
                    XmlElement eleItem = xmlDoc.CreateElement("item");
    
    
                    var text = xmlDoc.CreateTextNode(item);
                    eleItem.AppendChild(text);
    
                    foundNode.AppendChild(eleItem);
                    return true;
                }
                return false;
            }
    
         AddItemToRule(path, path, "id_Source", itemValue);
         AddItemToRule(path, path, "id_Article", itemValue);
         AddItemToRule(path, path, "id_Destination", itemValue);
               
