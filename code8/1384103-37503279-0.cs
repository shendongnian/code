    private void GetData()
    {
        // Get the ID using the name
        string id, yourData;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE name=@name", con);
        cmd.Parameters.Add("@name", "dimitris");
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
            id = reader["Id"].ToString();
        con.Close();
        // Get whatever you want using that ID
        cmd.CommandText = "SELECT * FROM Table2 WHERE Id=@id";
        cmd.Parameters.Add("@id", id);
        con.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
            yourData = reader["ColumnName"].ToString();
        con.Close();
    }
