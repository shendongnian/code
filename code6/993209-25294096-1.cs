    using(SqlDataReader reader = command.ExecuteReader())
         while(reader.Read())
         {
              if(reader[@"Date"] != DBNull.Value)
              {
                  string dbDate = reader[@"Date"].ToString();
                  DateTime date = DateTime.Parse(dbDate);
              }
         }
