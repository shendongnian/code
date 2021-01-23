            string path = "path";
            var element = "first_name";
            var value = "Dev";
            
            try
            {
                string fileLoc = path;
                XmlDocument doc = new XmlDocument();
                doc.Load(fileLoc);
                XmlNode node = doc.SelectSingleNode("/NameList/personDetail/" + element);
                if (node != null)
                {
                    node.InnerText = value;
                }
                else
                {
                    XmlNode root = doc.DocumentElement;
                    XmlElement elem;
                    elem = doc.CreateElement(element);
                    elem.InnerText = value;
                    root.AppendChild(elem);
                }
                doc.Save(fileLoc);
                doc = null;
            }
            catch (Exception)
            {
              
            }
