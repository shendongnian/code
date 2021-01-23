    using (var context = new YourDbModel())
    {
        var deletingAddresses = context.Category_Addresses
                                       .Where(ca => ca.Address.URL == "anytextIwrite")
                                       .Select(ca => ca.Address)
                                       .ToArray();
        foreach(var address in deletingAddresses)
        {
            context.Category_Addresses.Attach(address);
            var entry = context.Entry(address);
            entry.State = EntityState.Deleted;
        }
        context.SaveChanges();
    }
