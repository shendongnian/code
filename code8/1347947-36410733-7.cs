    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        float scale = trackBar1.Value / 100f;
        if (scale == 0) scale = 1;
        bool showGrid = true;  // inserted for testing
        // these graphics work with the scaled points:
        foreach (PointF pt in body) e.Graphics.FillEllipse(Brushes.Red, 
                                      pt.X - 2, pt.Y - 2, scale * 4, scale * 4);
        if (body.Count > 1) e.Graphics.DrawLines(Pens.Black, body.ToArray());
        // here we don't use points but calculate the coordinates, so we need to scale
        for (int x = 0; x < panel1.Width; x += trackBar2.Value)
            for (int y = 0; y < panel1.Height; y += trackBar2.Value)
            {
                if (showGrid == true)
                {
                    e.Graphics.FillEllipse(Brushes.Gray, 
                               scale * (x - 2), scale * (y - 2), scale * 4, scale * 4);
                }
                // Point gridpoint = new Point(x, y); // not sure what you do here..?
                // rastr.Add(gridpoint);   // maybe add the point scaled?
            }
    }
