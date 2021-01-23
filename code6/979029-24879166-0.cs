	public static void insert(List<myRecord> records)
	{
		string sql = "insert into myTable (col1, col2) values ";
		SqlConnection conn = new SqlConnection(myConnStr);
		SqlCommand cmd = new SqlCommand(sql, conn);
		int i = 0;
		foreach (record in records)
		{
			if (0 < i) sql += ",";
			sql += "(@col1_" + i + ",@col2_" + i + ")";
			cmd.Parameters.Add("@col1_" + i, System.Data.SqlDbType.Int).Value = record.Val1;
			cmd.Parameters.Add("@col2_" + i, System.Data.SqlDbType.Int).Value = record.Val2;
			++i;
		}
		// and so on...
	}
