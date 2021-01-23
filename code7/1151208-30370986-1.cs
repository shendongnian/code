    static IEnumerable<Tuple<int, double>> GetColumn(int columnIndex, double[,] a)
    {
        for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
            yield return Tuple.Create(i, a[i, columnIndex]);
    }
    
    double [,] data = ...;
    var column = GetColumn(4, data);
    var top4Indices = column.OrderBy(v => v.Second)
                            .Take(4)
                            .Select(v => v.First);
    foreach (int i in top4Indices)
        for (int j = data.GetLowerBound(1); j <= data.GetUpperBound(1); j++)
            data[i, j]...
