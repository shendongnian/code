    using (var con = new MySqlConnection(connectionString))
    using (var cmd = new MySqlCommand(sqlQuery, con)) 
    {
        cmd.CommandText = sqlQuery;
        cmd.Parameters.AddWithValue("@ID", "");
        //...
        cmd.ExecuteNonQuery();
    }
