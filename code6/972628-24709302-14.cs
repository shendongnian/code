    static void Place(double[,] src, double[,] dest, int destR, int destC)
    {
        for (int row = 0; row < src.GetLength(ROW_DIM); row++)
        {
            for (int col = 0; col < src.GetLength(COL_DIM); col++)
            {
                dest[row + destR, col + destC] = src[row, col];
            }
        }
    }
