    public override int SaveChanges()
            {
                try
                {
                    var debug = false;
    
                    if (debug)
                    {
                        var modifiedEntities = ChangeTracker.Entries()
                                .Where(p => p.State == EntityState.Deleted || p.State == EntityState.Detached).ToList();
    
                        foreach (var change in modifiedEntities)
                        {
                            var entityName = change.Entity.GetType().Name;
                            System.Diagnostics.Debug.WriteLine(string.Format("Entity {0}", entityName));
    
                        }
                    }
    
    
                    return base.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Error while Save Changes:");
                        Debug.WriteLine("Entity {0} has the following validation errors:", eve.Entry.Entity.GetType().Name);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("Property:{0}, Error: {1}",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
