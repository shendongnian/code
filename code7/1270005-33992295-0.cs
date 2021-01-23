    XDocument xDoc1 = XDocument.Load(@"C:\Input.xml");
    var elems = xDoc1.Descendants("Main");
    
    // Get all the main names in the input file (1 of each)
    string[] names = elems
        .Select(main => main.Attribute("Name").Value)
        .Distinct()
        .ToArray();
    
    XDocument xdoc2 = new XDocument();
    XElement root;
    xdoc2.Add(root = new XElement("Root"));
    foreach (string name in names)
    {
        XElement node = elems
            .LastOrDefault(a => a.Attribute("Name").Value == name);
        root.Add(new XElement(node));
    }
    
    xdoc2.Save(@"C:\Output.xml");
