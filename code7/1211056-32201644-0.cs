    // your module classes
        try
        {
        	// try block
        
        }
        catch (Exception ex)
                {
                    excpObj.SaveException(ex);
                }	
      // separate class for error log  
        public class ExceptionLog
        {
        	public static void SaveException(Exception ex)
            {
                // log your error using error logger
            }			
        }
