    public static int GetRowHeight(Matrix<Matrix<double>> m, int row)
    {
        int maxSeen = 0;
        for (int col = 0; col < m.Cols; col++)
        {
            if (m[row, col].Rows > maxSeen) { maxSeen = m[row, col].Rows; }
        }
        return maxSeen;
    }
    public static int GetColWidth(Matrix<Matrix<double>> m, int col)
    {
        int maxSeen = 0;
        for (int row = 0; row < m.Rows; row++)
        {
            if (m[row, col].Cols > maxSeen) { maxSeen = m[row, col].Cols; }
        }
        return maxSeen;
    }
