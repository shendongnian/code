                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml("<data><subdata><datatype id=\"1\" name=\"data1\"><xdim>2</xdim><ydim>1</ydim></datatype><datatype id=\"2\" name=\"data2\"><xdim>3</xdim><ydim>4</ydim></datatype></subdata></data>");
                var nodes = xmlDocument.SelectNodes("//datatype");
                string values = string.Empty;
                foreach (XmlNode node in nodes)
                {
                    values += node.Attributes["id"].Value;
                }
                nodes = xmlDocument.SelectNodes("//xdim");
                foreach (XmlNode node in nodes)
                {
                    values += node.InnerText;
                }
                nodes = xmlDocument.SelectNodes("//ydim");
                foreach (XmlNode node in nodes)
                {
                    values += node.InnerText;
                }
