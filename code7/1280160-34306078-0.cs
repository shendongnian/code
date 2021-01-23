    using (var connection = new SqlConnection(sConnectionString))
    {
        connection.Open();
        var sql = "INSERT INTO test (id) VALUES (@id)";
        using (var command = new SqlCommand(sql, connection))
        {
            // Adjust this to match the type of the id field
            var parameter = command.Parameters.Add("@id", SqlDbType.Int);
            for (int i = 1; i <= 5; i++)
            {
                parameter.Value = i; 
                command.ExecuteNonQuery();
            }
        }
    }
