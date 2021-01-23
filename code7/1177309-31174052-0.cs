    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        using (SqlCommand command = new SqlCommand(
        "SELECT Id, Name and CreatedDate  FROM movies WHERE id= @id", connection))
        {
    
            command.Parameters.Add(new SqlParameter("@id", id));
    
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows())
            {
                var id= reader["Id"].ToString();
                var name= reader["Name"].ToString();
            }
        }
    }
