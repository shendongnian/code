        using MySql.Data.MySqlClient; 
        ...
        var connectionString = "<insert connection string here>"; 
        using (var connection = new MySqlConnection(connectionString))
        { 
           connection.Open();
           var query = "select * from gestures group by name";
           var command = new MySqlCommand(query, connection);
           using (var reader = command.ExecuteReader())
           {
              while (reader.Read())
              {
                  var name = reader.GetString(0);
                  var pointX = reader.GetInt32(1);
                  var pointY = reader.GetInt32(2);
                  var pointZ = reader.GetInt32(3);
                 
                  Console.WriteLine($"{name}: {x},{y},{z}");
              }
           }
         }
        
