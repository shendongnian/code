         string Command = "SELECT This, That FROM YourTable WHERE YourCondition = @YC;";
    using (SqlConnection myConnection = new SqlConnection(YourConnectionString))
    {
        using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection))
        {
            myDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@YC", "foo"));
            DataTable YourDataTable = new DataTable();
            myDataAdapter.Fill(YourDataTable);
            GV1.DataSource = YourDataTable;
            GV1.DataBind();
        }
    }
