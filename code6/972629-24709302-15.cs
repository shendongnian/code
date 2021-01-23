    public static int GetRowHeight(Matrix<double[,]> m, int row)
    {
        int maxSeen = 0;
        for (int col = 0; col < m.Cols; col++)
        {
            if (m[row, col].GetLength(ROW_DIM) > maxSeen)
            {
                maxSeen = m[row, col].GetLength(ROW_DIM);
            }
        }
        return maxSeen;
    }
    public static int GetColWidth(Matrix<double[,]> m, int col)
    {
        int maxSeen = 0;
        for (int row = 0; row < m.Rows; row++)
        {
            if (m[row, col].GetLength(COL_DIM) > maxSeen)
            {
                maxSeen = m[row, col].GetLength(COL_DIM);
            }
        }
        return maxSeen;
    }
