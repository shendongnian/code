    var costs = db.Costs.Where(i => i.InvoiceId == id);
    
    foreach (var cost in costs)
    {
        //Delete all related costs.
        db.Costs.Remove(cost);
    }
    db.Invoices.Remove(invoiceToDelete);
