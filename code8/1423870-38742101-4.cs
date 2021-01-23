	public abstract class MyClass
	{
		private DataTable GetTableN(string sql, string[] pars)
		{
			DbCommand zapytanie = CreateCommand();
			DbDataAdapter da = CreateAdapter();
			...
		}
		
		protected abstract DbCommand CreateCommand();
		protected abstract DbDataAdapter CreateAdapter();
	}
	
	public class OdbcClass : MyClass
	{
		protected override DbCommand CreateCommand()
		{
			// create for odbc
		}
	
		protected override DbDataAdapter CreateAdapter()
		{
			// create for odbc
		}
	}
	
	public class PostgrClass : MyClass
	{
		protected override DbCommand CreateCommand()
		{
			// create for postgr
		}
	
		protected override DbDataAdapter CreateAdapter()
		{
			// create for postgr
		}
	}
