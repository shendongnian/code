    foreach (var invoice in invoiceCycleInvoices)
    {
        ctx.LoadProperty(invoice, "invoice_details");
        var invoiceDetail = invoice.GetRelatedEntity<Entity>("invoice_details");
    }
