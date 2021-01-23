    try
    {
        using (Entities dbContext = new Entities())
        {
            // Some database stuff
        }
    }
    catch (Exception ex)
    {
       if (!(ex is System.Data.Entity.Core.EntityException || ex is System.Data.Entity.Infrastructure.DbUpdateException || ex is System.Data.SqlClient.SqlException))
             throw;
          
          throw new MyApplicationException("Cannot access data store (" + ex.GetType().ToString() + ")", ex)
    }
