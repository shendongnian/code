            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("PayPalAPI", "urn:ebay:api:PayPalAPI");
            mgr.AddNamespace("eBLBaseComponents", "urn:ebay:apis:eBLBaseComponents");
            doc.LoadXml(xml);
            XmlNode Ack = doc.SelectSingleNode("//eBLBaseComponents:Ack", mgr);
            XmlNode node = doc.SelectSingleNode("//PayPalAPI:SetExpressCheckoutResponse", mgr);
            
            string strAck = null;
            if (Ack != null)
                strAck = Ack.InnerText.ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                //token = decoder["TOKEN"];
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.ToLower() == "token")
                    {
                        token = child.InnerText;
                    }
                }
            }
