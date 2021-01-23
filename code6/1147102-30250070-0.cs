    XDocument xmlDoc = XDocument.Load("test.xml");
    XElement root = xmlDoc.Element("table");
    Dictionary<string, List<XElement>> s1 = root.Elements("row")
                                                .GroupBy(ks => ks.Elements("col").Single(p => p.Attribute("name").Value == "cat_id").Value)
                                                .ToDictionary(ks => ks.Key, es => es.ToList());
