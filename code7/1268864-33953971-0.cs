    void Game_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        var g = e.Graphics;
        g.ResetTransform();
        g.MultiplyTransform (playerMatrix);
        ply.Draw(e.Graphics); // Draws the player
        g.ResetTransform();
        foreach (Guard grd in this.guards )
        {
            g.MultiplyTransform (grd.Matrix);
            grd.Draw(this.CreateGraphics()); // Draws the guard
            e.Graphics.DrawPolygon(Pens.Red, grd.GetPath()); // Draws the guard's path
            g.ResetTransform();
        }        
    }
