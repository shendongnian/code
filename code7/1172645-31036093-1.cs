    var columnTotals = new ConcurrentDictionary<int, decimal>();
    Parallel.ForEach(MyMatrix,
        // Each Task gets own dictionary
        () => new Dictionary<int, decimal>(),
        (row, state, colTots) =>
        {
            foreach (var column in row.Value)
            {
                if (!colTots.ContainsKey(column.Key))
                {
                    colTots[column.Key] = column.Value;
                }
                else
                {
                    colTots[column.Key] += column.Value;
                }
            }
            return colTots;
        },
        colTots =>
        {
            // Aggregate the dictionaries
            foreach (var column in colTots)
            {
                columnTotals.AddOrUpdate(column.Key, column.Value, 
                    (key, old) => old + column.Value);
            }
        });
