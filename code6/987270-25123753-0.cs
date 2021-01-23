    lock (myLock)
    {
         var invid = db.TransportJobInvoice.Where(c => c.CompanyId == CompanyId)
                .Max(i => i.InvoiceId);
         var invoiceId = invid == null ? 1 : (int)invid + 1;
    }
