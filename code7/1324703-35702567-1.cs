    using (var context = new NSTEntities())
    {
        using (var dbContextTransaction = context.Database.BeginTransaction()) 
        {
            try 
            { 
                [... foreach ... tableSet.Add(...) ...]
                context.SaveChanges(); 
 
                dbContextTransaction.Commit(); 
            } 
            catch (Exception exception) 
            { 
                dbContextTransaction.Rollback();
                // Log exception (never ignore)
            } 
        }
    }
