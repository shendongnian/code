     var connection = new SqlConnection("Connection String");
     try
     {
         var parameters = new
         { 
             Message = "Hello world!"
         };
     }
     finally
     {
         if (connection != null)
         {
             ((IDisposable)connection).Dispose();
         }
     }
