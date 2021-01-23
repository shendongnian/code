    void tm_TickDx(object sender, EventArgs e)
    {
        go = false;
        if (!go)
        {
            foreach (Control c in panel1.Controls)
            {
                if(c.GetType() == typeof(PictureBox))
                {
                    foreach(Control d in fireBox)
                    {
                        if (c.Bounds.IntersectsWith(d.Bounds))
                        {
                            panel1.Controls.Remove(c);
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
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    foreach (Control d in fireBox)
                    {
                        if (c.Bounds.IntersectsWith(d.Bounds))
                        {
                            panel1.Controls.Remove(c);
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
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    foreach (Control d in fireBox)
                    {
                        if (c.Bounds.IntersectsWith(d.Bounds))
                        {
                            panel1.Controls.Remove(c);
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
