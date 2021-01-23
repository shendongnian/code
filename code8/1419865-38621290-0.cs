    XmlSchemaSet schemas = new XmlSchemaSet();
    schemas.Add("", "CustomersOrders.xsd");
    Console.WriteLine("Attempting to validate");
    XDocument custOrdDoc = XDocument.Load("CustomersOrders.xml");
    bool errors = false;
    custOrdDoc.Validate(schemas, (o, e) =>
                     {
                         Console.WriteLine("{0}", e.Message);
                         errors = true;
                     });
    Console.WriteLine("custOrdDoc {0}", errors ? "did not validate" : "validated");
