    private void MappingExample()
    {
        var complex = GetQuery<ComplexObject>("select Id, null as OptionalAlias from customer").ToArray();
        var simple = GetQuery<int?>("select null as OptionalAlias from customer").ToArray();
    }
    private void DefaultIfEmptyExample()
    {
        var nulls = new int?[] { null, null };
        var nullsWithDefault = simple.DefaultIfEmpty(0); //still full of nulls
        var empty = new int?[] { };
        var emptyWithDefault = empty.DefaultIfEmpty(0); //has one item valued 0
    }
    private class ComplexObject
    {
        public int Id { get; set; }
        public int? OptionalAlias { get; set; }
    }
    private IEnumerable<T> GetQuery<T>(string sql)
    {
        var context = ContextManager.GetNew(); //proprietary, replace with your own
        var parms = new System.Data.SqlClient.SqlParameter[] { };
        return context.Database.SqlQuery<T>(sql, parms);
    }
