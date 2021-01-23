    public static void SaveClientHistory(String strMessage, String strClientIP)
    {
        try
        {
            // You can double-up using statements like this (for slightly better readability)
            using (SqlConnection objSqlConn = new SqlConnection(strConnectionString))
            using (SqlCommand objSqlCmd = new SqlCommand("procInsertHistory", objSqlConn))
			{
				objSqlCmd.CommandTimeout = 0;
				objSqlCmd.CommandType = CommandType.StoredProcedure;
				objSqlCmd.Parameters.AddWithValue("@strMessage", strMessage);
				objSqlCmd.Parameters.AddWithValue("@strClientIP", strClientIP);
				objSqlConn.Open();
				objSqlCmd.ExecuteNonQuery();
			}
        }
        catch (Exception Ex)
        {
			// You probably want to do something with the exception
			// (e.g., alert user, write to log.) Otherwise, rethrowing 
			// the exception doesn't help anything.
            throw Ex;
        }
    }
