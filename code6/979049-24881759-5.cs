    System.Data.SqlClient.SqlParameter sp = new Data.SqlClient.SqlParameter();
    sp.SqlDbType = SqlDbType.Structured;
    sp.Value = dt;
    sp.ParameterName = "@Combo";
    cmd.Parameters.Add(sp);
