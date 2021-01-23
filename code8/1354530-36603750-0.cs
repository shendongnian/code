          using (var xmlReader = new XmlTextReader(@"yourxmlfile"))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var nodeName = xmlReader.Name;
                        var attrName = xmlReader.GetAttribute("key");
                      
                        Console.WriteLine(nodeName);
                        Console.WriteLine(attrName);
                    }
                    if (xmlReader.NodeType==XmlNodeType.Text)
                    {
                        Console.WriteLine(xmlReader.Value);
                    }
                }
            }
