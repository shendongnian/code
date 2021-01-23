    public static class EFExtensions
    {
    	public static IEnumerable<T> DbQuery<T>(this DbContext db, string sql, params object[] parameters)
    	{
    		if (parameters != null && parameters.Length > 0 && parameters.All(p => p is OracleParameter))
    			return OracleDbQuery<T>(db, sql, parameters);
    		return db.Database.SqlQuery<T>(sql, parameters);
    	}
    
    	private static IEnumerable<T> OracleDbQuery<T>(DbContext db, string sql, params object[] parameters)
    	{
    		var connection = db.Database.Connection;
    		var command = connection.CreateCommand();
    		((OracleCommand)command).BindByName = true;
    		command.CommandText = sql;
    		command.Parameters.AddRange(parameters);
    		connection.Open();
    		try
    		{
    			using (var reader = command.ExecuteReader())
    			using (var result = ((IObjectContextAdapter)db).ObjectContext.Translate<T>(reader))
    			{
    				foreach (var item in result)
    					yield return item;
    			}
    		}
    		finally
    		{
    			connection.Close();
    			command.Parameters.Clear();
    		}
    	}
    }
