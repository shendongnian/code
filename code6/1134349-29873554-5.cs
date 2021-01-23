        static void Main(string[] args)
        {
            String inputfile = @"D:\Temp\cat.xml";
            XDocument xmldoc = XDocument.Load(inputfile);
            XElement root = xmldoc.Root;
            String val = "5";
            IEnumerable<XElement> vls = from e in root.Elements("Category") where e.Element("CategoryId").Value.Equals(val) select e;
            if (vls.Count() == 1)
            {
                vls.ElementAt(0).Element("CategoryName").Value = "Value has been changed";
            }
            xmldoc.Save(inputfile);
        }
