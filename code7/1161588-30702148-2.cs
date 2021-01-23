    using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Your result set or message
                }
    
                if(reader.NextResult())
                {
                   while (reader.Read())
                  {
                     //Your result set or message
                  }
                }
            }
