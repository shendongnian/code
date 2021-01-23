    internal int SaveChangesWithDefaultUser()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(x => x.Entity is IAuditableEntity
                        && (x.State == EntityState.Added || x.State == EntityState.Modified));
        var username = "SYSTEM";
        foreach (var entry in modifiedEntries)
        {
            IAuditableEntity entity = entry.Entity as IAuditableEntity;
                
            if (entity != null)
            {
                DateTime now = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = username;
                    entity.CreatedAt = now;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                }
                entity.UpdatedBy = username;
                entity.UpdatedAt = now;
            }
        }
        return base.SaveChanges();
    }
