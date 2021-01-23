    foreach (var item in items)
    {
        DataRow dr = griddt.NewRow();
        var data = dt
            .AsEnumerable()
            .Where(l => l.Field<int?>("ID") == item.curing_id)
            .Select(l => new {
                description = l.Field<string>("description"),
                status = l.Field<int?>("status")
            })
            .ToArray();
        dr[0] = data[0].description;
        dr[1] = data.Count();
        dr[2] = data.Count(d => d.Status == 1);
        dr[3] = data.Count(d => d.Status == 2);
        dr[4] = data.Count(d => d.Status == 3);
        griddt.Rows.Add(dr);
    }
