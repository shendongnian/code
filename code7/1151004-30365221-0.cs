    using (var connection = new SqlConnection())
    {
        connection.ConnectionString = "Your Connection String";
        using (var command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "scUsuarioCorrecto";
            command.Parameters.AddWithValue("@usrLogin", "Your login");
            command.Parameters.AddWithValue("@usrPassword", "Your password");
    
            connection.Open();
            object obj = command.ExecuteScalar();
            if (obj is bool)
            {
                bool correcto = (bool)obj;                
            }
            else
            {
               // either empty result set, or value in row is NULL.
            }  
        }
    }
