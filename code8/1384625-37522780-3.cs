    string query = "[dbo].[getUserDataByRecoveryCode]";
    SqlCommand cmd = new SqlCommand(query, conn);
    cmd.CommandType = CommandType.StoredProcedure;
    
    SqlParameter param1 = new SqlParameter();
    param1.DbType = DbType.String;
    param1.ParameterName = "@recoveryCode";
    param1.Value = HashVarchar;
    cmd.Parameters.Add(param1);
    
    
    try
    {
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
