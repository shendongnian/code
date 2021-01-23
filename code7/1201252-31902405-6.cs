	public int insertdetails(SqlCommand cmd)
		{
			SqlTransaction trans = null;
			try
			{
				trans = getconnection().BeginTransaction("trInsert");
				cmd.Transaction = trans;
				int a = cmd.ExecuteNonQuery();
				if (a > 0)
				{
					trans.Commit();
					return 1;
				}
				else
				{
					trans.Rollback("trInsert");
					return 0;
				}
