    public Color? CheckWinner(Label[,] board)
    {
        for (int row = 0; row < 19; row++)
        {
            // Initialize from the first cell
            int colorCount = 1;
            bool isBlack = board[0, row].BackColor == Color.Black;
            for (int column = 1; column < 19; column++)
            {
                bool cellIsBlack = board[column, row].BackColor == Color.Black;
                if (isBlack != cellIsBlack)
                {
                    // switched colors, so reset for this cell to be the first of the string
                    colorCount = 1;
                    isBlack = cellIsBlack;
                }
                else if (++colorCount == 5)
                {
                    return board[column, row].BackColor;
                }
            }
        }
        return null;
    }
