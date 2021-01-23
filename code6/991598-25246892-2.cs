    static class ArrayExtension
    {
        static int SafeGetAt(this int[,] a, int i, int j)
        {
            if(i < 0 || i >= a.GetLength(0) || j < 0 || j >= a.GetLength(1))
                return 0;
            return a[i, j];
        }
    }
