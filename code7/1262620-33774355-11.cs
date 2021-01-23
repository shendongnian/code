    private void labelClick(object sender, EventArgs e)
    {
        // set background color of clicked label here based on whose turn it is
        int[] coords = FindClickedLabelCoordinates(board, (Label)sender);
        Color? winner = CheckForWinner(board, coords[0], coords[1]);
        if (winner == Color.Black)
        {
            MessageBox.Show("Black is the winner!");
        }
        else if (winner == Color.White)
        {
            MessageBox.Show("White is the winner!");
        }
        // else winner is null, meaning no winner yet.
    }
    private int[] FindClickedLabelCoordinates(Label[,] board, Label label)
    {
        for (int r = 0; r < BoardHeight; r++)
        {
            for (int c = 0; c < BoardWidth; c++)
            {
                if (board[r, c] == label)
                    return new int[] { r, c };
            }
        }
        return null;
    }
