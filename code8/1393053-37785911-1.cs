    string query = "SELECT COUNT(*) FROM [User] WHERE UserName = @uname";
    
    using (var connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        using (var cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.Add(new SqlParameter("uname", "@admin"));
    
            int rowCount = (int)cmd.ExecuteScalar();
        }
    }
