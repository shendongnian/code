    string Command = "SELECT [UserName] FROM [aspnet_Users]";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection))
        {
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
        }
    }
