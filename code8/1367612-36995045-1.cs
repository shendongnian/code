    public static class DapperExtensions
    {
    	public static IEnumerable<IDictionary<string, string>> QueryDictionary(this IDbConnection connection, string query)
    	{
    		var data = Dapper.SqlMapper.Query(connection, query) as IEnumerable<IDictionary<string, object>>;
    		return data.Select(r => r.ToDictionary(d => d.Key, d => d.Value?.ToString()));
    	}
    }
