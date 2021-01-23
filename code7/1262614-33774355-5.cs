    private void label_Click(object sender, EventArgs e)
    {
        Label clickedLabel = (Label)sender;
        for (int r = 0; r < BoardHeight; r++)
        {
            for (int c = 0; c < BoardWidth; c++)
            {
                if (board[r, c] == clickedLabel)
                {
                    Color? winner = CheckForWinner(board, r, c);
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
            }
        }
        // any other logic here
    }
