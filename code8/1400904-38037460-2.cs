    var inputXml = XElement.Load("input.xml");
    var dict = inputXml.Element("Metadata")
        .Element("MyItemFieldDef")
        .Elements("ItemFieldDef")
        .ToDictionary(elem => elem.Attribute("id").Value,
            elem => elem.Attribute("aliasName").Value);
    XNamespace ns = "http://bla.com";
    var outputXml = new XElement(ns + "MyItems",
        new XAttribute(XNamespace.Xmlns + "ex", ns),
        inputXml.Elements("MyItem")
            .Select(item => new XElement(ns + "MyItem",
                item.Elements("MyItem")
                    .Select(myItem =>
                        new XElement(ns + "MyItem",
                            new XElement(ns + "Item_ID", myItem.FirstAttribute.Value))
                    ),
                item.Elements("Field")
                    .Select(field =>
                    {
                        if (field.HasElements)
                            return new XElement(ns + dict[field.Attribute("id").Value],
                                field.Descendants().Where(desc => !desc.HasElements)
                                    .Select(desc => new XElement(ns + "Item", desc.Value)));
                        else
                            return new XElement(ns + dict[field.Attribute("id").Value],
                                field.Value);
                    }))));
        
    outputXml.Save("output.xml");
