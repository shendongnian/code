    public static int[] RowSums(int[,] arr2D)
    {
        int numRows = arr2D.GetLength(0);
        int numColumns = arr2D.GetLength(1);
        int[] sums = new int[numRows];
        for (int row = 0; row < numRows; ++row)
        {
            for (int col = 0; col < numColumns; ++col)
            {
                sums[row] += arr2D[row, col];
            }
        }
        return sums;
    }
