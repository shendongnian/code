    string Command = "SELECT This, That FROM YourTable WHERE YourCondition = @YC;";
    using (MySqlConnection myConnection = new MySqlConnection(YourConnectionString))
    {
        using (MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(Command, myConnection))
        {
            myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@YC", "foo"));
            DataTable YourDataTable = new DataTable();
            myDataAdapter.Fill(YourDataTable);
            GV1.DataSource = YourDataTable;
            GV1.DataBind();
        }
    }
