    var result = table.AsEnumerable()
        .GroupBy(row => new { Col1 = row.Field<string>(0), Col2 = row.Field<string>(1) })
        .Select(g => new
        {
            Col1 = g.Key.Col1,
            Col2 = g.Key.Col2,
            Col3 = String.Join(", ", g.Select(row => row.Field<string>(2)))
        });
