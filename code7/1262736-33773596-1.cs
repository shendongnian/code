    public Color? CheckWinner(Label[,] board)
    {
        for (int row = 0; row < 19; row++)
        {
            // Initialize from the first cell
            int colorCount = 1;
            Color currentColor = board[0, row].BackColor;
            for (int column = 1; column < 19; column++)
            {
                Color cellColor = board[column, row].BackColor;
                if (currentColor != cellColor)
                {
                    // switched colors, so reset for this cell to be the first of the string
                    colorCount = 1;
                    currentColor = cellColor;
                }
                else if (++colorCount == 5 &&
                    (cellColor == Color.Black || cellColor == Color.White))
                {
                    // Only black and white should win; any other color can be used to
                    // represent e.g. "no piece played" or the like and this will
                    // still work.
                    return cellColor;
                }
            }
        }
        return null;
    }
