    DataTable dt = new DataTable();
    string Command = "SELECT ColumnName value FROM TableName";
    using (SqlConnection myConnection = new SqlConnection("YourConnectionString"))
    {
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);
        }
    }
