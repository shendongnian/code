    IEnumerable<T> items = null;
    // extract the dynamic sql query and parameters from predicate
    QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);
    using (IDbConnection cn = Connection)
    {
        cn.Open();
        items = cn.Query<T>(result.Sql, (object)result.Param);
    }
    return items;
