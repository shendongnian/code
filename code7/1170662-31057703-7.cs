    using (var ctx = new MyEntityContext()
    {
        TableSchema ts = ctx.GetDbTableSchema("MyTable");
        foreach (ColumnSchema cs in ts.Columns)
        {
            Debug.WriteLine("Column: {0}, {1}", cs.ColumnName, cs.IsNullable ? "NULL" : "NOT NULL");
        }
    }
