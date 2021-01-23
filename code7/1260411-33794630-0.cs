            int iteration = 0;
            public Label[,] board = new Label[19,19];
            const int WinLength = 5;
            const int BoardWidth = 19;
            const int BoardHeight = 19;
            gamePlay obj = new gamePlay();
        public Form1()
        {
            InitializeComponent();
    }
    
    private void labelClick (object sender, EventArgs e)
    {
    Label x = (Label)sender;
    
                if (x.BackColor == Color.Transparent)
                {
                    if (iteration % 2 == 0)
                    {
                        x.BackColor = Color.Black;
                    }
                    else
                    {
                        x.BackColor = Color.White;
                    }
                    iteration++;
                }
                else
                {
    
                }
    for (int r = 0; r < BoardHeight; r++)
            {
                for (int c = 0; c < BoardWidth; c++)
                {
                    if (board[r, c] == x)
                    {
                        Color? winner = obj.CheckForWinner(board, r, c);
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
    }
    
        class gamePlay
    {
            const int WinLength = 5;
    const int BoardWidth = 19;
    const int BoardHeight = 19;
    private Color? CheckForWinner(Label[,] board, int r, int c)
    {
        Color startColor = board[r, c].BackColor;
        for (int c1 = c - WinLength + 1; c1 <= c; c1++)
        {
            if (c1 >= 0 && c1 < BoardWidth && board[r, c1].BackColor == startColor)
            {
                MessageBox.Show("you win!");
                bool win = true;
                for (int c2 = c1 + 1; c2 < c1 + WinLength; c2++)
                {
                    if (c2 < 0 || c2 >= BoardWidth || board[r, c2].BackColor != startColor)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
    
                    return startColor;
                }
    
            }
        }
        return null;
    }
