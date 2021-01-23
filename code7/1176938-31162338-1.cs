    using (var db = new ApplicationContext())
    {        
        try {
           /* Query something */
        } catch(Exception e) {
           logger.Debug(e);
           throw; // rethrows the exception without losing the stack trace.
        }
    } 
