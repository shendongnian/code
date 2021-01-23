    Adapter = new SqlDataAdapter();
    //con is an open SQLConnection
    var cmd = new SQLCommand("GetData", con);
    cmd.Parameters.Add(new SqlParameter("@C_ID", 15));
    cmd.Parameters.Add(new SqlParameter("@U_ID", SomeValue ?? DBNull.Value));
    cmd.Parameters.Add(new SqlParameter("@P_ID", SomeValue ?? DBNull.Value));
    cmd.Parameters.Add(new SqlParameter("@SortIndex", 1));
    cmd.CommandType = CommandType.StoredProcedure;
    Adapter.SelectCommand = cmd;
    Adapter.Fill(Data);
