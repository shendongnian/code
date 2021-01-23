    using (OracleConnection conn = new OracleConnection( oradb ))
    {
          conn.Open();
          OracleCommand cmd = new OracleCommand("StoreProcedureName", con);
          cmd.CommandType = CommandType.StoredProcedure;   
     
          //specify command parameters 
          //and Direction
 
          using(OracleDataReader reader = cmd.ExecuteReader())
          {
              while (reader.Read())
              {
                 //string s = reader.GetInt32(0) + ", " + reader.GetInt32(1);
              }
          }                   
    }
