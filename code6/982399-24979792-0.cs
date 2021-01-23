	public IEnumerable<dynamic> Query(string sql, params object[] parms)
    {
        try
        {
            return QueryCore(sql, parms).ToArray();
        }
        catch (Exception ex)
        {
            throw new DbException(sql, parms, ex);
        }
    }
