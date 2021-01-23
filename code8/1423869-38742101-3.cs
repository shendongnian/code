	private DataTable GetTableN(string sql, string[] pars, MyFactory factory)
	{
		DbCommand zapytanie = factory.CreateCommand(...);
		DbDataAdapter da = new factory.CreateAdapter(...);
		...
	}
