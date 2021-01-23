    const int kwinningCount = 5;
    public Color? CheckWinner(Labels[,] board)
    {
        int columnCount = board.GetLength(0), rowCount = board.GetLength(1);
        for (int row = 0; row < rowCount; row++)
        {
            Color? lineResult = CheckWinnerForLine(board, 0, row, columnCount, 1, 0);
            if (lineResult != null)
            {
                return lineResult;
            }
            if (rowCount - row >= kwinningCount)
            {
                lineResult = CheckWinnerForLine(board, 0, row, rowCount - row, 1, 1);
                if (lineResult != null)
                {
                    return lineResult;
                }
            }
        }
        for (int column = 0; column < columnCount; column++)
        {
            Color? lineResult = CheckWinnerForLine(board, column, 0, rowCount, 0, 1);
            if (lineResult != null)
            {
                return lineResult;
            }
            if (column > 0 && columnCount - column >= kwinningCount)
            {
                lineResult =
                    CheckWinnerForLine(board, column, 0, columnCount - column, 1, 1);
                if (lineResult != null)
                {
                    return lineResult;
                }
            }
        }
        return null;
    }
    Color? CheckWinnerForLine(Labels[,] board,
        int column, int row, int count, int columnIncrement, int rowIncrement)
    {
        // Initialize from the first cell
        int colorCount = 1;
        Color currentColor = board[column, row].BackColor;
        while (--count > 0)
        {
            column += columnIncrement;
            row += rowIncrement;
            Color cellColor = board[column, row].BackColor;
            if (currentColor != cellColor)
            {
                // switched colors, so reset for this cell to be the first of the string
                colorCount = 1;
                currentColor = cellColor;
            }
            else if (++colorCount == kwinningCount && cellColor != Colors.Transparent)
            {
                return cellColor;
            }
        }
        return null;
    }
