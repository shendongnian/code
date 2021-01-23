                MySqlConnection connect  = new MySqlConnection(connectString);
                MySqlCommand command = connect.CreateCommand();
                command.CommandText  = "Select <VALUE> from <TABLE> order by <ID> desc limit <0,1>;"; 
                //Command to get query needed value from DataBase
                connect.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var result = reader.GetString(0);
                }
