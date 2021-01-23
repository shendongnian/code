        public mainForm()
        {
            InitializeComponent();
            InitializePieceControls();
        }
        private void InitializePieceControls()
        {
            int width = 15;
            int del = 3;
            int ystart = 50;
            int xstart = ystart+4 * width;
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (Board.isSpace(i, j))
                    {
                        Space sp = thisBoard.getSpace(i, j);
                        int xPos = getXFromIndex(i, j, width, xstart, ystart);
                        int yPos = getYFromIndex(i, j, width, xstart, ystart);
                        pieceObject piece = new pieceObject(getColor(sp));
                        piece.Click += myButton_Click;
                        piece.Size = new System.Drawing.Size(20, 20);
                        piece.Location = new System.Drawing.Point(xPos - del, yPos - del);
                        // It's not clear why you are doing this, as it will just make
                        // it impossible to see the ellipse that is drawn by the piece
                        // itself
                        piece.BackColor = getColor(sp);
                        this.Controls.Add(piece);
                    }
                }
            }
        }
        void myButton_Click(object sender, EventArgs e)
        {
            pieceObject piece = (pieceObject)sender;
            System.Console.WriteLine("Position: " + piece.Location + "Color: " + piece.BackColor);
            piece.Location = new Point(40, 40);
        }
