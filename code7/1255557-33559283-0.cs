            for (int i = 0; i < 361; i++)
            {
                board[i] = new Label { Name = "label" + i, Height = 55, Width = 55, MinimumSize = new Size(55, 55), Text = "label " + i };
            }
            int x = 0;
            int y = 0;
            foreach (var Label in board)
            {
                if (x >= 580)
                {
                    x = 0;
                    y = y + Label.Height + 55;
                }
                Label.Location = new Point(x, y);
                this.Controls.Add(Label);
                x += Label.Width;
            }
     
 
