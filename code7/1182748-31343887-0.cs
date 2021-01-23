    DateTime lastSyncTime = db.Table<SyncAudit>().AsEnumerable() // Do the rest of the processing in memory
        .Select(c => DateTime.Parse(c.SyncTime))
        .OrderByDescending(dt => dt)
        .FirstOrDefault();
    return lastSyncTime;
