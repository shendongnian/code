	ExecuteSQL(reader => {
		// write code that reads from the SqlDataReader here.
	});
	public void ExecuteSQL(string sql, Action<SqlDataReader> processRow)
	{
		using (SqlConnection conn = new SqlConnection("..."))
		{
			conn.Open();
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						processRow(reader);
					}
				}
			}
		}
	}
