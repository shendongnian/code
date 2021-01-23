    try
    {
        recordID = Convert.ToInt64(SqlHelper.ExecuteScalar(conn, CommandType.Text, sqlString, parms));
    }
    catch (Exception ex)
    {
       LogError(ex);
    }
