    var queues = new int[] { 1, 2, 3, 3, 4, 5, 6, 7, 7, 8, 8, 8, 8, 9 };
    var lookup = queues.ToLookup(i => i);
    int maxCount = lookup.Max(g => g.Count());
    List<List<int>> allbatches = Enumerable.Range(1, maxCount)
        .Select(count => lookup.Where(x => x.Count() >= count).Select(x => x.Key).ToList())
        .ToList();
