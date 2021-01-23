    invoiceItem = new InvoiceItem();
    invoiceItem.InvoiceID = node.Attributes[0].Value;
    invoiceItem.ProductID = prodID;
    invoiceItem.Description = description;
    invoiceItem.Capacity = capacity;
    invoiceItem.Quantity = qty;
    invoiceItem.UnitPrice = unitpx;
    invoiceItem.TotalPrice = (qty * unitpx);
    invoiceItems.Add(invoiceItem);
