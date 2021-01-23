    public IEnumerable<ICategory> Find()
    {
        using (IDbConnection _conn = GetConnection())
        {
            return _conn.Query<Category>("usp_Category", commandType: CommandType.StoredProcedure);
        }
    }
