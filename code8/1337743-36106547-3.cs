    using (MySqlConnection conn = new MySqlConnection())
        using (MySqlCommand cmd = new MySqlCommand()) {
        // ensure your connection is set
        conn.ConnectionString = "your connection string";
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO ThisTable (Value1, Value2) VALUES (@Param1, @Param2);";
        cmd.Parameters.AddWithValue("@Param1", userAdmin.YourProperty);
        cmd.Parameters.AddWithValue("@Param2", userAdmin.YourOtherProperty);
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
