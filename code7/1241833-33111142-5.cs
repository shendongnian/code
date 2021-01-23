        try
        {
            // Database operations starts 
            // perform database operations
            transaction.Commit();
        }
        catch // anything goes wrong
        {
            // rollback
            transaction.RollBack();
   
            // Rethowing the *Same* exception
            throw;
        }
