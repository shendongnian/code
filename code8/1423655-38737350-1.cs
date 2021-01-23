    var dbPath = "~/App_Data/db.sqlite".MapProjectPath();
    var dbFactory = new OrmLiteConnectionFactory(dbPath, SqliteDialect.Provider);
    using (var db = dbFactory.Open())
    {
        db.DropAndCreateTable<TableWithStrings>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 100; i++)
        {
            var row = TableWithStrings.Create(i);
            db.Insert(row);
        }
        "[db.sqlite] Time to INSERT 100 rows: {0}ms".Print(sw.ElapsedMilliseconds);
        sw = Stopwatch.StartNew();
        var rows = db.Select<TableWithStrings>();
        "[db.sqlite] Time to SELECT {0} rows: {1}ms".Print(rows.Count, sw.ElapsedMilliseconds);
    }
