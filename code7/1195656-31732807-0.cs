    OleDbConnection conn = null;
    OleDbDataReader reader = null;
    try
    {
        conn = new OleDbConnection(
            "Provider=Microsoft.Jet.OLEDB.4.0; " + 
            "Data Source=" + Server.MapPath("MyDataFolder/MyAccessDb.mdb"));
        conn.Open();
        OleDbCommand cmd = 
            new OleDbCommand("Select MemberID, Name, Surname FROM MemberDetails WHERE MemberID = @MemberID", conn);
        cmd.Parameters.AddWithValue("@MemberID", memberID);
        reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            memberID = reader.GetInt32(reader.GetOrdinal("MemberID"));
            name = reader["Name"].ToString();
            surname = reader["Surname"].ToString();
        }
    }
    finally
    {
        if (reader != null)  reader.Close();
        if (conn != null)  conn.Close();
    }
