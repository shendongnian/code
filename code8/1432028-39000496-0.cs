    using(var connection = new MySqlConnection(dbConnection))
    {
         connection.Open();
         using(var command = new MySqlCommand(createTableQuery, connection))
         {
              command.ExecuteNonQuery();
         }
    
         using(var command = new MySqlCommand(insertOrUpdate, connection))
         {
              command.Parameters.Add("..", SqlDbType = SqlDbType.Int).Value = 123456;
              command.ExecuteNonQuery();
         }
    }
