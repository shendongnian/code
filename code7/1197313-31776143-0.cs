    public static bool Delete(T Entity, out IList<string> validationErrors)
            {
                validationErrors = new List<string>();
    
                using (var db = new DatabaseContext())
                {
    
                    try
                    {
    
                        db.Entry(Entity).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        return true;
    
                    }
                    catch(Exception ex)
                    {
                        InsertValidationErrors(ex, validationErrors);
                        return false;
                    }
                }
            }
