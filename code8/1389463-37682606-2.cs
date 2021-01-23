    public Partner CreatePartner(...)
    {
        BillingAddress address = CreateAddress(...)
        return new Partner()
        {
            BillingAddress = address,
            OtherProperty = ...,
        };
    }
    public Partner AddPartner(...)
    {
        Partner partnerToAdd = CreatePartner(...);
        // don't allow partners without addresses:
        if (partnerToAdd.BillingAddress == null) throw ...
        using (var dbContext = new MyDbContext();
        {
            var addedPartner = dbContext.Partners.Add(partnerToAdd);
            dbContext.Savechanges();
            return addedPartner;
        }
    }
    public Partner RetrievePartner(long partnerId)
    {
        using (var dbContext = new MyDbContext();
        {
            return dbContext.Partners
                .Include(p => p.BillingAddress)
                .Single(p => p.Id == partnerId);
        }
    }
