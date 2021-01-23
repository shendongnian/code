    string query="INSERT INTO tempTable(name, gender, city) VALUES (@name, @gender, @city)";
    using (var connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandString = query;
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@name", list[0]);
            command.Parameters.AddWithValue("@gender", list[1]);
            command.Parameters.AddWithValue("@city", list[2]);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // your code...
            }
        }
    }
