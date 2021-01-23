     private static void CreateDatabaseXml(string path)
    {
        tbchrDataContext db = new tbchrDataContext();
        var rARefNum = db.T_ORDER_DETAILs.Select(i => i.RARefNum).Single();
        var customer = db.T_ORDER_HEADERs.Select(i => i.Customer).Single();
        var supplierName = db.T_ORDER_DETAILs.Select(i => i.SupplierName).Single();
        XDocument doc = new XDocument(
            // XML Declaration
            new XDeclaration("1.0", "utf-8", "yes"),
            // XML Root element to 3rd in nest
            new XElement(ns + "WMS",
            new XElement(ns + "Order",
            new XElement(ns + "Header", new XElement(ns + "RARefNum", rARefNum), 
                                        new XElement (ns + "WMSCategory", customer),
                                        new XElement (ns + "CustomerID", supplierName)))) );
    
        #endregion
        doc.Save(path);
    }
