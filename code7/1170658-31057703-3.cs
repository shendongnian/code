    using (var ctx = new MyEntityContext()
    {
        TableSchema ts = ctx.GetDbTableSchema("MyTable");
        foreach (ColumnSchema cs in ts.Columns)
        {
            Debug.WriteLine(cs.ColumnName);
        }
    }
