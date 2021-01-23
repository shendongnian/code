    for (int r = 0; r < 8; r++)
    {
     Label bricks = new Label();
     bricks.Location = new Point(x, y);
     bricks.BackColor = brickcolor[r]; //or bricks.ForeColor
     bricks.Width = 90;
     bricks.Height = 25;
     pnlGame.Controls.Add(bricks);
     y += 30;
    }
