    try
    {
    using (SqlConnection sourceCnx = new SqlConnection(SOURCE_CONN_STRING))
    {
        sourceCnx.Open();
        SqlCommand sysCmd = sourceCnx.CreateCommand();
        sysCmd.CommandText = "My query";
        sysCmd.ExecuteNonQuery();
    }
