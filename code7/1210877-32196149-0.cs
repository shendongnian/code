                var connection = new OracleConnection(YourConnectionString);
                try
                {
                    connection.Open();
    //AMK: Do some stuff with the db
    
    
                }
                catch (Exception exception)
                {
    //AMK: do some other stuff in case of error
    
                }
                finally
                {
    if(connection !=null && connection.State==ConnectionState.Open)               
      connection.Close();
                }
