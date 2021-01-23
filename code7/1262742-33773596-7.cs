    class GamePlay
    {
        private readonly int _winLength = 5;
        public GamePlay(int winLength)
        {
            _winLength = winLength;
        }
        public Color? CheckWinner(Label[,] board)
        {
            return CheckWinnerIterator(board).FirstOrDefault(color => color != null);
        }
        private IEnumerable<Color?> CheckWinnerIterator(Label[,] board)
        {
            int columnCount = board.GetLength(1), rowCount = board.GetLength(0);
            for (int row = 0; row < rowCount; row++)
            {
                // Horizontal
                yield return CheckWinnerForLine(board, 0, row, columnCount, 1, 0);
                // Diagonals starting in first column, upper-left to lower-right
                yield return CheckWinnerForLine(board, 0, row, rowCount - row, 1, 1);
                // Diagonals starting in first column, lower-left to upper-right
                yield return CheckWinnerForLine(board, 0, row, row + 1, 1, -1);
            }
            for (int column = 0; column < columnCount; column++)
            {
                // Vertical
                yield return CheckWinnerForLine(board, column, 0, rowCount, 0, 1);
                // Diagonals starting in first row, upper-left to lower-right
                yield return CheckWinnerForLine(board, column, 0, columnCount - column, 1, 1);
                // Diagonals starting in last row, lower-left to upper-right
                yield return CheckWinnerForLine(board, column, rowCount - 1, columnCount - column, 1, -1);
            }
        }
        Color? CheckWinnerForLine(Label[,] board,
            int column, int row, int count, int columnIncrement, int rowIncrement)
        {
            if (count < _winLength)
            {
                return null;
            }
            // Initialize from the first cell
            int colorCount = 1;
            Color currentColor = board[row, column].BackColor;
            while (--count > 0)
            {
                column += columnIncrement;
                row += rowIncrement;
                Color cellColor = board[row, column].BackColor;
                if (currentColor != cellColor)
                {
                    // switched colors, so reset for this cell to be the first of the string
                    colorCount = 1;
                    currentColor = cellColor;
                }
                else if (++colorCount == _winLength && cellColor != Color.Transparent)
                {
                    return cellColor;
                }
            }
            return null;
        }
    }
