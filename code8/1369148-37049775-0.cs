     XmlNodeList amounts = xml.GetElementsByTagName("Amount");
                foreach (XmlElement amount in amounts)
                {
                    if (amount.ParentNode != null)
                    {
                        if (amount.ParentNode.Name.Equals("ItemPrice"))
                        {
                            Console.WriteLine("Item Price"+amount.InnerText);
                        }
                        if (amount.ParentNode.Name.Equals("ShippingPrice"))
                        {
                            Console.WriteLine("Shipping Price" + amount.InnerText);
    
                        }
                    }
                }
