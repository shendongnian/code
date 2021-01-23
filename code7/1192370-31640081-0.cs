    var xml = XDocument.Load("XMLFile1.xml");
    XNamespace xs = "http://www.w3.org/2001/XMLSchema";
    var elementNames = xml.Root.Element("NewDataSet").Element(xs + "complexType")
        .Element(xs + "choice").Elements(xs + "element").Select(e => e.Attribute("name").Value);
    foreach (var name in elementNames)
    {
        Console.WriteLine(name);
    }
