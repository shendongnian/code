    if (e.KeyCode == Keys.Right) {
        j_figure = 2;
        x += velocity;
        if (playerBox.Bounds.IntersectsWith(panel1.Bounds)) {
            x = panel1.Left - playerBox.Width;
        } else if (playerBox.Bounds.IntersectsWith(panel2.Bounds)) {
            x = panel2.Left - playerBox.Width;
        }
        playerBox.Location = new Point(x, y);
    } else if (e.KeyCode == Keys.Left) {
        j_figure = 2;
        x -= velocity;
        if (playerBox.Bounds.IntersectsWith(panel1.Bounds)) {
            x = panel1.Right;
        } else if (playerBox.Bounds.IntersectsWith(panel2.Bounds)) {
            x = panel2.Right;
        }
        playerBox.Location = new Point(x, y);
    } ...
