    string[] ops = {"D","I"};
    IEnumerable<long> removedRows;
    IEnumerable<long> addedRows;
    using (IDataReader reader = _changeTable.ExecuteReader())
    {
        var allRows = reader.Select(r => new { LogID = r["LogID"], Operation = r["SYS_CHANGE_OPERATION"] })
                            .Where(r => ops.Contains(r.Operation)
                            .ToList();
        removedRows = allRows.Where(r => r.Operation.Equals("D"))
                             .Select(r => (long)r.LogID);
        
        addedRows = allRows.Where(r => r.Operation.Equals("I"))
                           .Select(r => (long)r.LogID);
    }
    
