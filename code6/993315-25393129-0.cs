    var customerIds = new[]{1001, 1003};
    var query = 
            from c in context.WinflexCustomers
            where customerIds.Contains(c.InternalClientNum)
            select new { c.InternalClientNum, c.TaxID2 }
    foreach(var customer in query)
    {
        var clientNumber = customer.InternalClientNum;
        var taxId = c.TaxID2;
        // do stuff...
    }
