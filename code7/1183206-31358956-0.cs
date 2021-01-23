    public static bool checkUsername(string userName)
    {
	SqlClient.SqlCommand withCmd = new SqlClient.SqlCommand();
	bool result = false;
	withCmd.Connection.Open();
		withCmd.CommandType = CommandType.text;
 	    withCmd.CommandText = "SELECT COUNT(username) AS Users FROM users WHERE (username = @Username)"
	    withCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.VarChar, 16)).Value = userName;
	try {
        int intResult;
        object scalarResult = withCmd.ExecuteScalar();
        if ((scalarResult != DBNull.Value)
           && (scalarResult  != null)
           && (int.TryParse(scalarResult, out intResult)))
		              result = (intResult==1);
	} catch (Exception ex) {
		result = false; 		// hmm, bad...can't tell handle error...
	} finally {
			// only close if we opened the connection above  ...
			withCmd.Connection.Close();
		}
	}
	return result;
    }
