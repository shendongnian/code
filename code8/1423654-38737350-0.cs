    var dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
    using (var db = dbFactory.Open())
    {
        db.DropAndCreateTable<TableWithStrings>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 100; i++)
        {
            var row = TableWithStrings.Create(i);
            db.Insert(row);
        }
        "[:memory:] Time to INSERT 100 rows: {0}ms".Print(sw.ElapsedMilliseconds);
        sw = Stopwatch.StartNew();
        var rows = db.Select<TableWithStrings>();
        "[:memory:] Time to SELECT {0} rows: {1}ms".Print(rows.Count, sw.ElapsedMilliseconds);
    }
