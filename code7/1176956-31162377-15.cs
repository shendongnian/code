     var db = new ApplicationContext();
     try
     {
        /* Query something */                  
     }
     catch(Exception e)
     {
        logger.Debug(e);
     }
     finally
     {
        if (db!= null)
        {
          ((IDisposable)myRes).Dispose();
        }
     }
