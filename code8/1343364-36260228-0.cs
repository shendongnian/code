    try
            {
    	        db.Entity.Add(entity);
    	        db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
    		    foreach (var validationErrors in dbEx.EntityValidationErrors)
    		    {
    		        foreach (var validationError in validationErrors.ValidationErrors)
    		        {
    		            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
    		        }
    		    }
            }
