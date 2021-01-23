    //sets the node or remove
         public static void SetOrRemoveNodeValue(XElement root, string xPath, string attributeName, string value)
                {
                    XElement currentNode = root.XPathSelectElement(xPath);
                    if (currentNode != null)
                    {
                        if (currentNode.Attributes().FirstOrDefault(att => att.Name.LocalName.Equals(attributeName)) != null)
                        {
                            if (value == string.Empty)
                            {
                                currentNode.Attribute(attributeName).Remove();
                            }
                            else
                            {
                                currentNode.Attribute(attributeName).Value = value;
                            }
                        }
