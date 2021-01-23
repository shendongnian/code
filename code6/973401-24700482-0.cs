	public static void WithDB(Action<SqlConnection, DbCommand> action)
	{
        using(var con = Common.CreateConnection())
        {
            var cmd = con.CreateCommand();
            action(con, cmd);
        }
	}
