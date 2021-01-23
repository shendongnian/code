        using (var db = new SQLite.SQLiteConnection(this.DBPath))
        {
            var query = db.Table<SyncAudit>()
                       .OrderByDescending(c => c.SyncTime)
                       .FirstOrDefault();
            return query.Select(c => c.SyncTime).ToString();
        }
