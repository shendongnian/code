    void CheckCollision()
    {
        // Get all enemies from playground
        var enemies = panel1.Controls.Cast<Control>();
        // Compare bounds of all fireboxes to bounds of enemies
        var colidedEnemies = enemies.Where(en => fireBox.Any(fb => fb.Bounds.IntersectsWith(en.Bounds)));
        
        // Delete all collided enemies
        colidedEnemies.ToList().ForEach(en => panel1.Controls.Remove(en));
    }
    
    void tm_TickDx(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            // Check collision
            CheckCollision();
            if (fireBox[count - 1].Location.X < panel1.Location.X + panel1.Width)
            {
                fireBox[count - 1].Left = fireBox[count - 1].Left + 25;
            }
            else
            {
                tm.Stop();
                go = true;
                tm.Tick -= test;
            }
    
        }
    
    }
    
    void tm_TickSx(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            // Check collision
            CheckCollision();
            if (fireBox[count - 1].Location.X > panel1.Location.X - fireBox[count - 1].Width)
                fireBox[count - 1].Left = fireBox[count - 1].Left - 25;
            else
            {
                tm.Stop();
                go = true;
                tm.Tick -= test;
            }
    
        }
    
    }
    
    void tm_TickUp(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            // Check collision
            CheckCollision();
            if (fireBox[count - 1].Location.Y > panel1.Location.Y - fireBox[count - 1].Height)
                fireBox[count - 1].Top = fireBox[count - 1].Top - 25;
            else
            {
                tm.Stop();
                go = true;
                tm.Tick -= test;
            }
    
        }
    
    }
    
    void tm_TickDw(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            // Check collision
            CheckCollision();
            if (fireBox[count - 1].Location.Y < panel1.Location.Y + panel1.Height)
                fireBox[count - 1].Top = fireBox[count - 1].Top + 25;
            else
            {
                tm.Stop();
                go = true;
                tm.Tick -= test;
            }
        }
    }
