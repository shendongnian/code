    string xml = "<root><entry name='something'>" +
                  "<members>" + 
                    "<member>aaa</member>" + 
                    "<member>bbb</member>" + 
                  "</members>" + 
                "</entry>" + 
                "<entry name='something_else'>" + 
                  "<members>" + 
                    "<member>ccc</member>" + 
                    "<member>ddd</member>" + 
                 "</members>" +
                "</entry></root>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var memsList = doc.SelectNodes("//entry");
                foreach (XmlNode a in memsList)
                {
                    Console.WriteLine(a.Attributes["name"].Value);
                    var memList = a.SelectNodes("members/member");
                    foreach(XmlNode x in memList)
                        Console.WriteLine(x.InnerText);
                }
