    private void Form1_Load(object sender, EventArgs e)
            {
                char[,] gameArray = new char[30, 80];
                for (int i = 0; i < gameArray.GetLength(0); i ++)
                {
                    for(int j = 0; j < gameArray.GetLength(1); j++)
                    {
                        Button button = new Button();
                        button.Height = 30;
                        button.Width = 30;
                        button.Location = new Point(30 * i, 30 * j);
                        this.Controls.Add(button);
                    }
                }
            }
