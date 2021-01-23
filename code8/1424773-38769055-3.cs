    int count = default(int);
    IEnumerable<int> values1 = Enumerable.Range(1, 200)
        .OrderBy(o => Guid.NewGuid())
        .Take(100);
    IEnumerable<int> values2 = values1
        .OrderBy(o => Guid.NewGuid())
        .Take(50)
        .Select(o => { count++; return o; })
        .ToList();
