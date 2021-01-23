    try
    {
        db.SaveChanges();
    }
    catch (DbEntityValidationException ex)
    {
        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
        {
            DbEntityEntry entry = item.Entry;
    
            //...
            
            // Rollback changes
    
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
            
        }
    }
