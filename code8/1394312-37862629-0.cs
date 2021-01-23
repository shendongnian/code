    using (var connTran = _dbconnection.OpenWithTransaction())
    {
       try
       {
           connTran.Insert("usp_Lookup_InsertHeader", entity, new { lookupHeader = entity });
           connTran.Commit();
       }
       catch(Exception ex)
       {
          logException(ex.Message);       
          connTran.Rollback();
          throw;
       } 
    }
