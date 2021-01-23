    XDocument xDoc = XDocument.Load("AnXml.xml");
    XDocument copy = new XDocument(xDoc);
    Console.WriteLine("xDoc before change copy: {0}", xDoc.ToString());
    copy.Root.Add(new XElement("NewElement", 5));
    copy.Element("FirstNode").Element("ChildNode").Attribute("attributeOne").SetValue(2);
    Console.WriteLine("xDoc after change copy: {0}", xDoc.ToString());
    Console.WriteLine("copy after change copy: {0}", copy.ToString());
    Console.ReadKey();
