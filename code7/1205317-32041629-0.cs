    string oldRelID = part.GetIdOfPart(imagePart);
                        foreach (XmlElement list in pictureNodeList)
                        {
                            XmlNodeList elementList = list.GetElementsByTagName("a:blip");
                            foreach (XmlNode node in elementList)
                            {
                                foreach (XmlAttribute att in node.Attributes)
                                {
                                    if (att.Value == oldRelID)
                                    {
                                        XmlNodeList trevList = list.GetElementsByTagName("p:cNvPr");
                                        foreach (XmlNode trevnode in trevList)
                                        {
                                            foreach (XmlAttribute trevatt in trevnode.Attributes)
                                            {
                                                if (trevatt.Name == "descr")
                                                {
                                                    mapReference = trevatt.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
