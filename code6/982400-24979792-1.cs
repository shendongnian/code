    public IEnumerable<dynamic> Query(string sql, params object[] parms)
    {
        try
        {
            return QueryCore(sql, parms);
        }
        catch (Exception ex)
        {
            throw new DbException(sql, parms, ex);
        }
    }
    private IEnumerable<dynamic> QueryCore(string sql, params object[] parms)
    {
        using (var connection = CreateConnection())
        {
            using (var command = CreateCommand(sql, connection, parms))
            {
                using (var reader = command.ExecuteReader())
                {
					var results = new List<dynamic>();
                    while (reader.Read())
                    {
                        results.Add(reader.ToExpando());
                    }
					
					return results;
                }
            }
        }
    }
