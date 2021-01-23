    public static IQueryable<fileUpload> FilterByThisStuff(this DbSet<fileUpload> db, ... invoice, ... helpDeskFault, ... ppmScheduleLine, ... doc)
    {
        if (!string.IsNullOrEmpty(jobSearchParams.PIR) && string.IsNullOrEmpty(jobSearchParams.StoreName))
        {
            return db.Where(invoice=>invoice.PurchaseInvoiceReference == jobSearchParams.PIR);
        }
        if (string.IsNullOrEmpty(jobSearchParams.PIR) && !string.IsNullOrEmpty(jobSearchParams.StoreName))
        {
            return db.Where(...);     
        }
        return db.Where(...);
    };
