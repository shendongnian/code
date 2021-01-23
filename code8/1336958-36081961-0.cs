    XElement root = new XElement(tu + "InvoiceRequest",
                        new XAttribute(XNamespace.Xmlns + "tu", "http://www.test.com/"),
                        new XAttribute("Id", "data"),
                        new XElement(tu + "Header"
                            ));
    root.Add(CreateNode(tu, "MessageID", item.XMLMessageID));
    // etc...
    if (item.TaxNrSeller != 0 || item.TaxNrSeller != null)
        root.Add(CreateNode(tu, "TaxNrSeller", item.TaxNrSeller));
