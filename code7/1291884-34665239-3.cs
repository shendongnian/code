    public class NVarcharInterceptor : IDbCommandInterceptor
	{
		public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
		public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
		public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
		public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
		public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
		public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			if (command != null && !string.IsNullOrWhiteSpace(command.CommandText))
				command.CommandText = command.CommandText.Replace("N''", "''");
		}
	}
