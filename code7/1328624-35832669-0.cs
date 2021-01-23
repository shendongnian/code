	private static int ExecuteSqlCount(string statement, SqlParameter[] paramsSql)
	{
		using (Entities dbContext = new Entities())
		{
			var total = dbContext.Database.SqlQuery<int>(statement, paramsSql).First();
			return total;
		}
	}
