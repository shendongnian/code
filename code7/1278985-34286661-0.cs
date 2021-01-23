    // Create parent object
    var invoice = new Entity("invoice");
    // Create list of child objects
    var invoiceDetailList = new List<Entity>() { new Entity("invoicedetail"), new Entity("invoicedetail") };
    // Add child records to parent record's RelatedEntities
    invoice.RelatedEntities.Add(new Relationship("invoice_invoicedetails"), new EntityCollection(invoiceDetailList));
    // Create all in one transaction.
    service.Create(invoice);
