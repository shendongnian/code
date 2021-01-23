    var query = Items
        .GroupBy(i => i.Item2, i => i.Item3)
        .SelectMany(g => new[]
        {
            new { b = g.Key, c = g.First() },
            new { b = g.Key, c = String.Join(" ", g.Skip(1)) },
        })
        .Select((x, i) => Tuple.Create(i + 1, x.b, x.c));
