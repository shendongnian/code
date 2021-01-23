    new [] { "A", "Be", "D", "C", "Be", "C", "D", "C"}
    .GroupBy(v => v)
    .Select(g => new { Value = g.Key, Count = g.Count() })
    .OrderByDescending(g => g.Count)
    .Select(g => g.Value)
