    var columnTotals = new ConcurrentDictionary<int, decimal>();
    Parallel.ForEach(MyMatrix,
        () => new Dictionary<int, decimal>(),
        (row, state, colTots) =>
        {
            foreach (var column in row.Value)
            {
                colTots[column.Key] += column.Value;
            }
            return colTots;
        },
        colTots =>
        {
            foreach (var column in colTots)
            {
                columnTotals.AddOrUpdate(column.Key, 0, (key, old) => old + column.Value);
            }
        });
