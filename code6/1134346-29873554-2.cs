    static void Main(string[] args)
        {
            String inputfile = @"D:\Temp\cat.xml";
            XDocument xmldoc = XDocument.Load(inputfile);
            XElement root = xmldoc.Root;
            root.Add(new XElement("Category", new XElement("CategoryID", "8"), new XElement("CategoryName", "Added by LinqXML")));
            xmldoc.Save(inputfile);
        }
