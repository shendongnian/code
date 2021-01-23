    using (MiniProfiler.Current.Step("Get Count using ProfiledConnection - sql recorded"))
    {
        using (var conn = new ProfiledDbConnection(context.Database.Connection, MiniProfiler.Current))
        {
            conn.Open();
            newCount = conn.Query<int>(sql).Single();
            conn.Close();
        }
    }
