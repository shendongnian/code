    using (OracleConnection conn = new OracleConnection( oradb ))
    {
          string sql = @"SELECT department_name FROM departments 
                         WHERE department_id = @department_id";
          conn.Open();
          OracleCommand cmd = new OracleCommand(sql, conn);
               
          //specify command parameters
          cmd.Parameters.Add(new OracleParameter("@department_id", 10));
          
          using(OracleDataReader reader = cmd.ExecuteReader())
          {
              while (reader.Read())
              {
                 //string s = reader.GetString(0);
              }
          }                   
    }
