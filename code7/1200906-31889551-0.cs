    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        String query = @"INSERT INTO table2
                           SELECT Name, Family
                             FROM table1";
        SqlCommand command = new SqlCommand(query, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
