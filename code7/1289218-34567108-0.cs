     MySqlConnection connection = new MySqlConnection(myConnection);
     connection.Open();
     // remove the order by and add a where with a parameter placeholder
     var command = new MySqlCommand(
                         "select ImageI from database.employee where id = @id",
                         connection);
     // setup parameter and add to command
     command.Parameters.AddWithValue("@id", imageid);
     // execute
     MySqlDataReader dr = command.ExecuteReader();
     
