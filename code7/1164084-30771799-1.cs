<!-- -->
    // the alias names need to match property names
    string query = "SELECT column1 AS [A], column2 AS [B] FROM ..."
    using (var db = new EFDbContext())
    {
        var perms = db.Database.SqlQuery<QueryResult>(query)
            .ToDictionary(r => r.A, r => r.B);
    }
