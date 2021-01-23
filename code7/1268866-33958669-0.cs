     void Game_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var saved = e.Graphics.Save();
            ply.Draw(e.Graphics); // Draws the player
            foreach (Guard grd in this.guards )
            {
                grd.Draw(e.Graphics); // Draws the guard
                e.Graphics.Restore(saved);
                e.Graphics.DrawPolygon(Pens.Red, grd.GetPath()); // Draws the guard's path
            }
            
          
        }
