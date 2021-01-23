    string _ConnectionString = ConfigurationManager.ConnectionStrings["DataSourceName"].ConnectionString;
    SqlConnection sqlconn = new SqlConnection(_ConnectionString);
    SqlCommand sqlcmd = new SqlCommand("sp_StoredProcName", sqlconn);
    sqlcmd.CommandType = CommandType.StoredProcedure;
    sqlconn.Open();
    SqlParameter sqlParam1 = sqlcmd.Parameters.AddWithValue("@param", "ParamText");
    SqlDataReader reader = sqlcmd.ExecuteReader();
