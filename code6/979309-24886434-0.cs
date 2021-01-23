    using (connection = new SqlConnection("connection string here"))
    {
        using (command = new SqlCommand(@"select * from tbl1", connection))
        {
            connection.Open();
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // read first grid
                }
                if(reader.NextResult())
                {
                    while (reader.Read())
                    {
                        // read second grid
                    }
                }
            }
        }
    }
