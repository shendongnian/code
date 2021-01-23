    public override int SaveChanges()
    {
        var now = DateTime.Now;
        var entities = ChangeTracker.Entries<AuditedEntity>();
        foreach (var item in entities)
        {
            if (item.State == EntityState.Added)
            {
                item.CreatedBy = user;
                item.CreatedDate = now;
                item.ModifiedBy = user;
                item.ModifiedDate = now;
            }
            else if (item.State == EntityState.Modified)
            {
                item.ModifiedBy = user;
                item.ModifiedDate = now;
            }
        }
        return base.SaveChanges();
    }
