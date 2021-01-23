    public static List<T> Sort<T, U>(this List<T> Source, Func<T, U> OrderFunc) { return Source.OrderBy(OrderFunc).ToList(); }
    /// <summary>
    /// Sorts lists down the specified number of columns
    /// for instance:
    /// 1  4  7
    /// 2  5  8
    /// 3  6  9
    /// 
    /// instead of:
    /// 1  2  3
    /// 4  5  6
    /// 7  8  9
    public static List<T> ColumnSort<T, U>(this List<T> Source, Func<T, U> OrderFunc, int NumColumns) where T : new() {
        var sorted = Source.Sort(OrderFunc);
        var m = (int)Math.Ceiling(sorted.Count / (double)NumColumns);
        var n = NumColumns;
        var flipped = new T[m*n];
        for (var i = 0; i < sorted.Count; i++ )
        {
            var t = i % m * n + i / m;
            flipped[t] = sorted[i];
        }
        return flipped.ToList();
    }
