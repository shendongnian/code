    static void Main(string[] args)
    {
        int[,] array = new int[4, 4]
        {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };
        Rotate(array, 2, 2, 3, 3, true);
        Rotate(array, 1, 0, 3, 2, false);
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }
    private static void Rotate(int[,] array, int x1, int y1, int x2, int y2, bool clockwise)
    {
        int[] r1 = CopyFromRow(array, x1, y1, x2 - x1 + 1);
        int[] r2 = CopyFromRow(array, x2, y1, x2 - x1 + 1);
        int[] c1 = CopyFromColumn(array, x1, y1, y2 - y1 + 1);
        int[] c2 = CopyFromColumn(array, x1, y2, y2 - y1 + 1);
        if (clockwise)
        {
            Array.Reverse(c1);
            Array.Reverse(c2);
            CopyToColumn(array, r1, x1, y2);
            CopyToColumn(array, r2, x1, y1);
            CopyToRow(array, c1, x1, y1);
            CopyToRow(array, c2, x2, y1);
        }
        else
        {
            Array.Reverse(r1);
            Array.Reverse(r2);
            CopyToColumn(array, r1, x1, y1);
            CopyToColumn(array, r2, x1, y2);
            CopyToRow(array, c1, x2, y1);
            CopyToRow(array, c2, x1, y1);
        }
    }
    private static void CopyToColumn(int[,] array, int[] row, int x1, int y1)
    {
        for (int i = 0; i < row.Length; i++)
        {
            array[x1 + i, y1] = row[i];
        }
    }
    private static void CopyToRow(int[,] array, int[] col, int x1, int y1)
    {
        for (int i = 0; i < col.Length; i++)
        {
            array[x1, y1 + i] = col[i];
        }
    }
    private static int[] CopyFromColumn(int[,] array, int x1, int y1, int length)
    {
        int[] row = new int[length];
        
        for (int i = 0; i < length; i++)
        {
            row[i] = array[x1 + i, y1];
        }
        return row;
    }
    private static int[] CopyFromRow(int[,] array, int x1, int y1, int length)
    {
        int[] col = new int[length];
        
        for (int i = 0; i < length; i++)
        {
            col[i] = array[x1, y1 + i];
        }
        return col;
    }
