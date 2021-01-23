    dt.Rows.Add("A", 10);
    dt.Rows.Add("A", 20);
    dt.Rows.Add("B", 20);
    var result = dt.AsEnumerable()
           .GroupBy(x => x.Field<string>("ID"))
           .Select(g => new { ID = g.Key, Amount = g.Sum(z => z.Field<int>("Amount")) });
    DataTable t2 = dt.Clone();
    foreach (var grp in result)
        t2.Rows.Add(grp.ID, grp.Amount);
