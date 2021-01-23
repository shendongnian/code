    static void Main ()
    {
        // Input array
        double[,] u = {
            { 1, 9, 3 },
            { 0, 3, 4 },
            { 3, 4, 5 },
            { 3, 6, 8 },
            { 3, 5, 7 },
        };
        // Get dimension sizes, specify column to order by
        int count = u.GetLength(0), length = u.GetLength(1), orderBy = 2;
        // Result array
        double[,] v = new double[count, length];
        // Construct a list of indices to sort by
        var indices = Enumerable.Range(0, count).OrderBy(i => u[i, orderBy]).ToList();
        // Copy values from input to output array, based on these indices
        for (int i = 0; i < count; i++)
            for (int j = 0; j < length; j++)
                v[i, j] = u[indices[i], j];
        PrintArray(u);
        Console.WriteLine();
        PrintArray(v);
    }
    static void PrintArray (double[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < a.GetLength(1); j++)
                Console.Write(a[i, j]);
            Console.WriteLine();
        }
    }
