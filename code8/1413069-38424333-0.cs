    var query = db.SomeTable
        .GroupBy(x => new { x.Your, x.Key })
        .OrderBy(g => g.Key.Your).ThenBy(g => g.Key.Key)
        .AsEnumerable()
        .Select((g, i) => new { g, i })
        .SelectMany(x =>
            x.g.Select(y => new
            {
                y.Your,
                y.Columns,
                y.And,
                y.Key,
                DenseRank = x.i,
            }
        );
