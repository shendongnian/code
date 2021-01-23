    string frdt = drow1["release_year"].ToString();
    DateTime Result = new DateTime(int.Parse(frdt), 1, 1);
    string Command = "INSERT INTO TABLENAME (COLUMNNAME) VALUES (@DATEVALUE);"; // TODO
    using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (MySqlCommand myCmd = new MySqlCommand(Command, mConnection))
        {
            myCmd.Parameters.AddWithValue("@DATEVALUE", Result);
            int RowsAffected = myCmd.ExecuteNonQuery();
        }
    }
