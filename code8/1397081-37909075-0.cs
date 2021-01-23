    string query = "SELECT Nickname,str_Id  FROM your_table_name" +
                   " WHERE Nickname =@nickname  AND Password = @password";
    MySqlConnection con = new MySqlConnection();
    // Creating parameterized command
    MySqlCommand cmd = new MySqlCommand(query, con);
    cmd.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = nickname;
    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
    DataTable table = new DataTable();
    // Collect the details to a DataTable
    adapter.Fill(table);
    if (table.HasErrors) // Means there is some record found
    {
        // Get theUnique ID for the matching record
        string uniqueId = table.Rows[0]["str_Id"].ToString();
        // Update active state for that particular user
        query = "Update your_table_name set active='0' Where str_Id=@str_Id";
        cmd = new MySqlCommand(query, con);
        cmd.Parameters.Add("@str_Id", MySqlDbType.VarChar).Value = uniqueId;
        // Execute command here
    }
    else
    {
        // Print message thet no user found
    }
