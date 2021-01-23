    int[] testArray = { 1, 1, 2, 3, 2, 2, 2, 1 }; // Output wanted {2,2,2};
    
    int[] maxSequence = testArray .Select((n, i) => new { Value = n, Index = i})
        .OrderBy(s => s.Value)
        .Select((o, i) => new { Value = o.Value, Diff = i - o.Index } )
        .GroupBy(s => new { s.Value, s.Diff})
        .OrderByDescending(g => g.Count())
        .First()
        .Select(f => f.Value)
        .ToArray();
