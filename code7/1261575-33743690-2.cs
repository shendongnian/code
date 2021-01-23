    void Main()
    {
        var input = new double[,] {{5,7,6},{2,9,6},{2,5,6},{4,8,1}};
        
        Sort(input);
        // Input is now:
        // {{2,5,6},{2,9,6},{4,8,1},{5,7,6}}
    }
    
    public T[,] Sort<T>(T[,] data) where T : IComparable
    {
        // Transform to array of arrays.
        var rows = new T[data.GetLength(0)][];
        for (var i = 0; i< data.GetLength(0); ++i)
        {
            rows[i] = new T[data.GetLength(1)];
            for (var j = 0; j < data.GetLength(1); ++j)
                rows[i][j] = data[i, j];
        }
    
        // Sort rows using a custom array comparer.
        Array.Sort(rows, new ArrayComparer<T>());
    
        // Write data back to input array.
        // You can skip this part and return if you're ok with working on T[][].
        for (var i = 0; i< data.GetLength(0); ++i)
            for (var j = 0; j < data.GetLength(1); ++j)
                data[i, j] = rows[i][j];
    
        return data;
    }
    
    public class ArrayComparer<T> : IComparer<T[]> where T : IComparable
    {
        public int Compare(T[] x, T[] y)
        {
            var comparer = Comparer<T>.Default;
            // Compare elements as long as they're different.
            for(var i = 0; i < x.Length; ++i)
            {
                var compareResult = comparer.Compare(x[i], y[i]);
                if (compareResult != 0) return compareResult;
            }
            return 0;
        }
    }
