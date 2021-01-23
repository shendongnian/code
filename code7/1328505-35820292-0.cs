    using (var context = new CustomContext()) 
    { 
        using (var dbContextTransaction = context.Database.BeginTransaction()) 
        { 
            try 
            { 
                // various context operations
                context.SaveChanges(); 
    
                int id = insertedEntity.Id;
    
                // do stuff with the id 
    
                dbContextTransaction.Commit(); 
            } 
            catch (Exception) 
            { 
                dbContextTransaction.Rollback(); 
            } 
        } 
    } 
