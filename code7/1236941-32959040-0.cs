        if (e.KeyCode == Keys.Right)
            {
                j_figure = 2;
                x += velocity;
                playerBox.Location = new Point(x, y);
                if (playerBox.Bounds.IntersectsWith(panel1.Bounds))
                {
                    x = panel1.Left - playerBox.Width;
                }
                else if (playerBox.Bounds.IntersectsWith(panel2.Bounds))
                {
                    x = panel2.Left - playerBox.Width;
                }
             }
    ...
    // code for other directions
    ...
    // again but this time outside the KeyCode if statements
    playerBox.Location = new Point(x, y);
    }
