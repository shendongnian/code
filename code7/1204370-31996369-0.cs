    string sql = "SELECT ID, "
        + "ERR1 AS ErrorCode, "
        + "ERR2 AS ErrorCode, "
        + "ERR3 AS ErrorCode "
        + "FROM ERR_TB";
    List<Entry> entries = connection.Query<Entry, BpcError, BpcError, BpcError, Entry>(sql,
    (entry, e1, e2, e3) =>
    {
        if (e1 != null)
            entry.Errors.Add(e1);
        if (e2 != null)
            entry.Errors.Add(e2);
        if (e3 != null)
            entry.Errors.Add(e3);
    
        return entry;
    },
    splitOn: "ErrorCode, ErrorCode, ErrorCode")
    .ToList();
