	var reader = ExecuteSQL("SELECT ...");
	while (reader.Read()) // <-- this fails, because the connection is closed.
	{
		// process row...
	}
	public SqlDataReader ExecuteSQL(string sql)
	{
		using (SqlConnection conn = new SqlConnection("..."))
		{
			conn.Open();
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				return cmd.ExecuteReader();
			}
		}
	}
