    List<Point> points = new List<Point>();   // List<T> is wonderful !
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
         points.Add(e.Location);
         panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
         g = e.Graphics;    // only ever use this one for persistent graphics!!
         foreach( Point pt in points)
            g.FillEllipse(Brushes.Red, pt.X, pt.Y,  10, 10);
    }
