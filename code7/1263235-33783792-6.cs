    using (var connection = new MySqlConnection(...))
    {
        connection.Open();
        using (var command = new MySqlCommand("INSERT INTO 'databases' VALUES(@name)", connection)
        {
            var parameter = command.Parameters.Add("@name", MySqlDbType.LongText);
            foreach (...)
            {
                parameter.Value = line;
                command.ExecuteNonQuery();
            }
        }
    }
