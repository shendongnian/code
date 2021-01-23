    DateTime timestamp;
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"db"].ConnectionString))
         using(SqlCommand command = new SqlCommand(query, connection))
              using(SqlDataReader reader = command.ExecuteReader())
                  while(reader.Read())
                  {
                       if(reader[@"ColumnName"] != DBNull.Value)
                       {
                            string date = reader[@"ColumnName"].ToString();
                            timestamp = DateTime.Parse(date);
                       }
                   }
