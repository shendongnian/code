    static private dbConnectionString = "CONNECTION DETAILS";  
    
    using (OracleConnection connection = new OracleConnection(dbConnectionString))
    {
       try 
       {   
          connection.Open();
          using (OracleCommand command = connection.CreateCommand())
          {
              ......
              using(OracleDataReader rdr = command.ExecuteReader())
              {
              }
          }
       }
       catch(OracleException ex)
       {
       }
       finally 
       {
          connection.Close();   
       }
    }
