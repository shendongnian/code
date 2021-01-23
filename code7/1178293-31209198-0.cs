    try
    {
      JCoContext.begin(destination); 
      try
      {
        // your function calls here
        // probably bapiTransactionCommit.execute(destination);
      }
      catch(AbapException ex)
      {
        // probably bapiTransactionRollback.execute(destination);
      } 
    }
    catch(JCoException ex)
    {
      [...]
    }
    finally
    {
      JCoContext.end(destination);
    }
