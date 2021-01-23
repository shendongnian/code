    foreach (XElement el in doc.Root.Descendants("Metric"))
    {
        XElement newDoc =
            new XElement("Document", 
                new XElement("DataSet", 
                    new XElement("Dimension", 
                        new XAttribute(el.Parent.Attribute("name")), 
                        el)
                    )
                )
            );
        newDoc.Save(el.Attribute("name").Value.Replace(" ", "_") + ".xml");
    }
