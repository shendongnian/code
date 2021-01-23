    new XElement(tu + "InvoiceIdentifier",
        new XElement(tu + "BusinessPremiseID", item.BussinesspremiseID),
        new XElement(tu + "ElectronicDeviceID", item.ElectronicDeviceID),
        new XElement(tu + "InvoiceNumber", item.InvoiceNumber),
        item.TaxNrSeller != 0 ? new XElement(tu + "TaxNrSeller", item.TaxNrSeller) : null
    );
