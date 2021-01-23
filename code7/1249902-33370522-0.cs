    DataTable dt1 = new DataTable();
    using(var da = new OleDbDataAdapter("SELECT * FROM MainData where ID=@ID", connection))
    {
        da.SelectCommand.Parameters.Add("@ID", OleDbType.SmallInt).Value = short.Parse(BestScoreID);
        // no need to open/close the connection with dataadapter.Fill:
        da.Fill(dt1);
    }
