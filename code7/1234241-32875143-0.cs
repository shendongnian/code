    List<string> list = new List<string>();
    while (reader.Read())
    {
        list.Add(reader["Name"].ToString());
    }
    reader.Close(); 
    con.Close();
