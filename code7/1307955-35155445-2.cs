    foreach (XElement el in doc.Root.Descendants("Metric"))
    {
        XElement newDoc =
            new XElement("Document",
                new XAttribute(doc.Root.Attribute("name")), 
                new XElement("DataSet", 
                    new XAttribute(el.Parent.Parent.Attribute("name")),
                    new XElement("Dimension", 
                        new XAttribute(el.Parent.Attribute("name")), 
                        el)
                    )
                )
            );
        newDoc.Save(el.Attribute("name").Value.Replace(" ", "_") + ".xml");
    }
