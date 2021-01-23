    string queryString = "select nome from produto where cod_produto like '%" + codigo + "%'";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
               // get the results here
               reader.GetString(0); // result of the first field.
            }
        }
        finally
        {
            // Always call Close when done reading.
            reader.Close();
        }
    }
