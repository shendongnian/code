    try
    {
        db.SaveChanges();
    }
    catch (DbEntityValidationException ex)
    {
        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
        {
            // Get entry
    
            DbEntityEntry entry = item.Entry;
            string entityTypeName = entry.Entity.GetType().Name;
    
            // Display or log error messages
    
            foreach (DbValidationError subItem in item.ValidationErrors)
            {
                string message = string.Format("Error '{0}' occurred in {1} at {2}", 
                         subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                Console.WriteLine(message);
            }
            
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
