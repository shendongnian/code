    var intNodes = node.SelectNodes("./int");
                    foreach (var intNode in intNodes)
                    {
                        if (((XmlElement) intNode).Attributes["name"].Value == "mob")
                        {
                            MobID = ((XmlElement) intNode).Attributes["value"].Value;
                        }
                    }
