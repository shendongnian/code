    var inputXml = XElement.Load("input.xml");
    var dict = inputXml.Element("Metadata")
        .Element("MyItemFieldDef")
        .Elements("ItemFieldDef")
        .ToDictionary(elem => elem.Attribute("id").Value, elem => elem.Attribute("aliasName").Value);
    XNamespace ns = "http://bla.com";
    var outputXml = new XElement(ns + "MyItems",
        new XAttribute(XNamespace.Xmlns + "ex", ns),
        inputXml.Elements("MyItem")
            .Select(item => new XElement(ns + "MyItem",
                item.Elements("Field")
                    .Select(field =>
                    {
                        if (field.HasElements)
                            return new XElement(ns + dict[field.Attribute("id").Value], field.Element("ListValues")
                                .Elements("ListValue").Select(value => new XElement(ns + "Item", value.Value)));
                        else
                            return new XElement(ns + dict[field.Attribute("id").Value], field.Value);
                    }))));
        
    outputXml.Save("output.xml");
