    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.ScaleTransform(zoom, zoom);
   
        // some demo drawing:
        Rectangle rect = panel1.ClientRectangle;
        g.DrawEllipse(Pens.Firebrick, rect);
        using (Pen pen = new Pen(Color.DarkBlue, 4f)) g.DrawLine(pen, 22, 22, 88, 88);
    }
