    void tm_TickDx(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            // Foreach control inside your panel
            foreach (Control enemie in panel1.Controls)
            {
                // If control is a PictureBox - preventing future features
                if(enemie.GetType() == typeof(PictureBox))
                {
                    // Foreach fireball thats moving - could get filtered better
                    foreach(Control fireball in fireBox)
                    {
                        // If there IS a collision between enemie and fireball
                        if (enemie.Bounds.IntersectsWith(fireball.Bounds))
                        {
                            panel1.Controls.Remove(enemie);
                        }
                    }
                }
            }
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
            // Foreach control inside your panel
            foreach (Control enemie in panel1.Controls)
            {
                // If control is a PictureBox - preventing future features
                if (enemie.GetType() == typeof(PictureBox))
                {
                    // Foreach fireball thats moving - could get filtered better
                    foreach (Control fireball in fireBox)
                    {
                        // If there IS a collision between enemie and fireball
                        if (enemie.Bounds.IntersectsWith(fireball.Bounds))
                        {
                            panel1.Controls.Remove(enemie);
                        }
                    }
                }
            }
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
            // Foreach control inside your panel
            foreach (Control enemie in panel1.Controls)
            {
                // If control is a PictureBox - preventing future features
                if (enemie.GetType() == typeof(PictureBox))
                {
                    // Foreach fireball thats moving - could get filtered better
                    foreach (Control fireball in fireBox)
                    {
                        // If there IS a collision between enemie and fireball
                        if (enemie.Bounds.IntersectsWith(fireball.Bounds))
                        {
                            panel1.Controls.Remove(enemie);
                        }
                    }
                }
            }
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
            // Foreach control inside your panel
            foreach (Control enemie in panel1.Controls)
            {
                // If control is a PictureBox - preventing future features
                if (enemie.GetType() == typeof(PictureBox))
                {
                    // Foreach fireball thats moving - could get filtered better
                    foreach (Control fireball in fireBox)
                    {
                        // If there IS a collision between enemie and fireball
                        if (enemie.Bounds.IntersectsWith(fireball.Bounds))
                        {
                            panel1.Controls.Remove(enemie);
                        }
                    }
                }
            }
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
