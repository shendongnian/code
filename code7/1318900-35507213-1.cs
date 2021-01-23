    var conditions = new List<Func<DataRow, bool>>();
    if (...)
        conditions.Add(r => ...);
    if (...)
        conditions.Add(r => ...);
    ...
    var query = dtTest.AsEnumerable();
    foreach (var cond in conditions)
        query = query.Where(cond);
    var result = query.CopyToDataTable();
