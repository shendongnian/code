    var xDoc = XDocument.Load(xmlFilePath);
    IEnumerable<Element> elements = xDoc
        .Descendants("Element")
        .Select(x => new Element
        {
            Country = x.Element("Country").Value,
            Min = Convert.ToInt32(x.Element("Min").Value),
            NotXmlProperty = "Value"
        });
