    using (var mySqlConnection = new SqlConnection(connectionString))
    using (var mySqlCommand = new SqlCommand(query, mySqlConnection)){
        mySqlConnection.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
        }
        reader.Close();
    }
