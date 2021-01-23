    Adapter = new SqlDataAdapter();
    var cmd = new SQLCommand("GetData");
    cmd.Parameters.Add(new SqlParameter("@C_ID", 15));
    cmd.Parameters.Add(new SqlParameter("@U_ID", SomeValue ?? DBNull.Value));
    cmd.Parameters.Add(new SqlParameter("@P_ID", SomeValue ?? DBNull.Value));
    cmd.Parameters.Add(new SqlParameter("@SortIndex", 1));
    cmd.CommandType = CommandType.StoredProcedure;
    Adapter.SelectCommand = cmd;
    Adapter.Fill(Data);
