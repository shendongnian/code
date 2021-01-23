    using (OracleConnection conn = new OracleConnection( oradb ))
    {
          string sql = "select * from tablename";
          conn.Open();
          OracleCommand cmd = new OracleCommand(sql, conn);
               
          //specify command parameters if any
          
          using(OracleDataReader reader = cmd.ExecuteReader())
          {
              while (reader.Read())
              {
                 //string s = reader.GetInt32(0) + ", " + reader.GetInt32(1);
              }
          }                   
    }
