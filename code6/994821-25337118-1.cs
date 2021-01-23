    public int SaveClientHistory(String strConnectionString, String strMessage, String strClientIP)
    {
		// You can double-up using statements like this (for slightly better readability)
		using (SqlConnection objSqlConn = new SqlConnection(strConnectionString))
		{
			objSqlConn.ConnectionTimeout = 10; // Creating a connection times out after ten seconds 
			objSqlConn.Open();
			using (SqlCommand objSqlCmd = new SqlCommand("procInsertHistory", objSqlConn))
			{
				objSqlCmd.CommandTimeout = 10; // Creating a command times out after ten seconds
				objSqlCmd.CommandType = CommandType.StoredProcedure;
				objSqlCmd.Parameters.AddWithValue("@strMessage", strMessage);
				objSqlCmd.Parameters.AddWithValue("@strClientIP", strClientIP);    				
				return objSqlCmd.ExecuteNonQuery();
			}
		}
    }
