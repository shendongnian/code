    DataTable dt = new DataTable("Optional TableName");
    using (var con = new SqlConnection("Connection-String Here"))
    using (var da = new SqlDataAdapter("StoredProcedureName", con))
    {
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        // you don't need to open/close the connection with Fill
        da.Fill(dt);
        dataSet.Tables.Add(dt);
    }
