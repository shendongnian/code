    var results = new List<Table>();
    using (var db1 = dbFactory.OpenDbConnection("db1"))
    using (var db2 = dbFactory.OpenDbConnection("db2"))
    {
        results.AddRange(db1.Select<Table>(q => q.Category = category));
        results.AddRange(db2.Select<Table>(q => q.Category = category));
    }
