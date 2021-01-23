    using (SqlConnection mySqlConnection = new SqlConnection(connectionString))
    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection)){
        mySqlConnection.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
        }
        reader.Close();
    }
