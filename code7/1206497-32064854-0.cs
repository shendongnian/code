    public static String ToXmlString(this Object xmlObj)
            {
                var objectType = xmlObj.GetType();
                var document = new XmlDocument();
                document.LoadXml(xml: xmlObj.ToString());
                StringBuilder xmldata = new StringBuilder();
                var ele = (XmlElement)document.FirstChild;
                foreach(var item in document)
                {
                    xmldata.Append(item);
                }
                Console.WriteLine(ele.InnerXml); 
                return xmldata.ToString();
            }
