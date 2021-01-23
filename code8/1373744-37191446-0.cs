    public override int SaveChanges()
    {
        IEnumerable<DbEntityEntry<BaseEntity>> entries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach (DbEntityEntry<BaseEntity> entry in entries)
        {
            entry.Entity.LastUpdated = DateTime.Now;
        }
        return base.SaveChanges();
    }
