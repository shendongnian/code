    var ediDefault = default(DateTime).AddHours(12);
    foreach (var invoice in 
                 invoicesForSite.Where(i =>
                                       i.StartReadDate != ediDefault  &&
                                       i.EndReadDate != ediDefault))
    {
        // Logic here for filtered invoices...
    }
