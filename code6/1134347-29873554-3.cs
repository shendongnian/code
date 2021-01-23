        static void Main(string[] args)
        {
            String inputfile = @"D:\Temp\cat.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(inputfile);
            XmlNode root = xmldoc.DocumentElement;
            //Method 1
            XmlElement category = xmldoc.CreateElement("Category");
            XmlElement catid = xmldoc.CreateElement("CategoryId");
            XmlElement catname = xmldoc.CreateElement("CategoryName");
            
            catid.InnerText = "6";
            catname.InnerText = "The newly added category";
            category.AppendChild(catid);
            category.AppendChild(catname);
            root.AppendChild(category);
            //Method 2
            XmlElement category2 = xmldoc.CreateElement("Category");
            String catdata = String.Format("<CategoryId>{0}</CategoryId><CategoryName>{1}</CategoryName>", "7", "Adding data by innerXML");
            category2.InnerXml = catdata;
            root.AppendChild(category2);
            xmldoc.Save(inputfile);
        }
