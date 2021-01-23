    using (var connection = new SqlConnection(con))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // your logic to process the response
                }
            }
        }
    }
