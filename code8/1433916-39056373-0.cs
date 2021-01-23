    public virtual Guid Add<T>(T newItem) where T : class
    {
        using (var context = new ApplicationDbContext())
        {
            context.Set<T>().Add(newItem);
            context.SaveChanges();
            context.Entry(newItem).
            return newItem.RecordID;//here it returns your GUID
        };
    }
