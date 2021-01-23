    using (SqlConnection connection = MyDBConnection)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("SQL Query Here", connection) { CommandTimeout = 0 };
    
    
        using (var reader = command.ExecuteReader())
        {
            try
            {
                while (reader.Read())
                {
    
                    string test0 = reader[0].ToString();
                    string test1 = reader[1].ToString();
                    string test2 = reader[2].ToString();
                    string test3 = reader[3].ToString();
    
                }
    
            }
            catch (Exception e)
            {
    
                //Make some Noise
    
            }
        }
    }
