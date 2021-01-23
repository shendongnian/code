    public partial class Form1 : Form
    {
        const int WinLength = 5;
        const int BoardWidth = 19;
        const int BoardHeight = 19;
        private bool isBlackTurn = true;
        private Label[,] board = new Label[BoardHeight, BoardWidth];
        private GamePlay WinCheck = new GamePlay(WinLength);
        public Form1()
        {
            InitializeComponent();
            int x = this.Location.X + 10;
            int y = this.Location.Y + 15;
            // create 361 labels, set their properties
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    Label label = new Label();
                    label.Parent = this;
                    label.Name = "label" + i;
                    label.BackColor = Color.Transparent;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Size = new Size(30, 30);
                    label.Click += new System.EventHandler(this.labelClick);
                    this.Controls.Add(board[i, j]);
                    label.BringToFront();
                    board[i, j] = label;
                }
            }
            // set the position of the label
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    board[i, j].Location = new Point(x, y);
                    //set distance between labels
                    if (x >= 755)
                    {
                        x = this.Location.X + 10;
                        y += 42;
                    }
                    else
                    {
                        x += 43;
                    }
                }
            }
        }
        private void labelClick(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;
            if (clickedLabel.BackColor != Color.Transparent)
            {
                return;
            }
            clickedLabel.BackColor = isBlackTurn ? Color.Black : Color.White;
            isBlackTurn = !isBlackTurn;
            Color? winner = WinCheck.CheckWinner(board);
            if (winner == Color.Black)
            {
                MessageBox.Show("Black is the winner!");
            }
            else if (winner == Color.White)
            {
                MessageBox.Show("White is the winner!");
            }
            else
            {
                return;
            }
            foreach (Label label in board)
            {
                label.BackColor = Color.Transparent;
            }
        }
    }
