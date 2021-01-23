    var groupQuery = dt.AsEnumerable()
        .Select(r => new { ID = r.Field<int>("ID"), Percentage = r.Field<int>("Percentage") })
        .Where(x => x.ID != 0 && x.ID != 100)
        .GroupBy(x => x.ID);
    DataTable groupingTable = dt.Clone(); // empty, same columns
    foreach(var grp in groupQuery)
        groupingTable.Rows.Add(grp.Key, grp.Sum(x => x.Percentage));
