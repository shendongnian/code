	try
	{
		using (SqlConnection sqlConn = new SqlConnection(Config.ConnStr))
		using (SqlCommand sqlCmd = new SqlCommand("spr_Web_Content", sqlConn))
		{
			sqlCmd.CommandType = CommandType.StoredProcedure;
			sqlCmd.Parameters.Add("@Op", SqlDbType.VarChar, 100).Value = "SelectAllForNavigation";
			sqlConn.Open();
			using (SqlDataReader sqlDr = sqlCmd.ExecuteReader())
			{
				DataTable dt = new DataTable();
				dt.Load(sqlDr);
				return dt;
			}
		}
	}
	catch (Exception)
	{
		return null;
	}
