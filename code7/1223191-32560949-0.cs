    SqlParameter paramAcc = new SqlParameter("@AccountId", accountID);
    paramAcc.DbType = DbType.Int32;
    paramAcc.Direction = ParameterDirection.Input;
    cmd.Parameters.Add(paramAcc);
    
    if (from != null)
    {
        SqlParameter paramSDate = new SqlParameter("@StartDate", from);
        paramSDate.DbType = DbType.DateTime;
        paramSDate.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(paramSDate);
    }
    
    if (to != null)
    {
        SqlParameter paramEDate = new SqlParameter("@EndDate", to);
        paramEDate.DbType = DbType.DateTime;
        paramEDate.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(paramEDate);
    }
