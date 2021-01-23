    public override int SaveChanges()
    {
        var entries = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
    
        foreach(var entry in entries)
        {
            if(entry.State == EntityState.Added)
            {
                entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
            }
            else 
            {
                entry.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
            }
        }
        return base.SaveChanges();
    }
