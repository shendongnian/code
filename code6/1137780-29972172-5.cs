    using (var mySqlConnection = new SqlConnection(connectionString))
    {
        using (var mySqlCommand = new SqlCommand(query, mySqlConnection))
        {
            mySqlConnection.Open();
            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                }
            }
        }
    }
