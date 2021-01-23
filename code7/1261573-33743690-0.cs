    void Main()
    {
        var input = new double[,] {{5,7,6},{2,9,6},{2,5,6},{4,8,1}};
        
        Sort(input);
        // Input is now:
        // {{2,5,6},{2,9,6},{4,8,1},{5,7,6}}
    }
    
    public double[,] Sort(double[,] data) 
    {
        // Transform to array of arrays.
        var rows = new double[data.GetLength(0)][];
        for (var i = 0; i< data.GetLength(0); ++i)
        {
            rows[i] = new double[data.GetLength(1)];
            for (var j = 0; j < data.GetLength(1); ++j)
                rows[i][j] = data[i, j];
        }
        
        // Sort rows using a custom array comparer.
        Array.Sort(rows, new ArrayComparer());
        
        // Write data back to input array.
        // You can skip this part and return if you're ok with working on double[][].
        for (var i = 0; i< data.GetLength(0); ++i)
            for (var j = 0; j < data.GetLength(1); ++j)
                data[i, j] = rows[i][j];
                
        return data;
    }
    
    public class ArrayComparer : IComparer<double[]>
    {
        public int Compare(double[] x, double[] y)
        {
            for(var i = 0; i < x.Length; ++i)
            {
                if (x[i] > y[i]) return 1;
                if (x[i] < y[i]) return -1;
            }
            return 0;
        }
    }
