    void RenderAnts(object sender, PaintEventArgs e)
    {
        //pictureBox1.Invalidate();   // don't do this here!
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        foreach (ant a in ants)
        {
            c = Brushes.DarkBlue;
            if (a.role == AntRole.Scout)
            {
                a.Move(i);
                c = Brushes.Red;
            }
            e.Graphics.FillRectangle(c, a.position.x, a.position.y, 1, 1);
            G.FillRectangle(Brushes.Gray, a.position.x, a.position.y, 1, 1);
        }
    }
