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
        // Check for a null resource.
        if (db!= null)
        // Call the object's Dispose method.
          ((IDisposable)myRes).Dispose();
     }
