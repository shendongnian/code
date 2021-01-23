     SqlCommand command = new SqlCommand(
              "SELECT @@IDENTITY FROM TABLE",
              connection);
            connection.Open();
    
            SqlDataReader reader = command.ExecuteReader();
    
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
            }
