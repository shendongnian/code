    using System.Drawing.Drawing2D;
    //
    GraphicsPath path = new GraphicsPath();
    path.AddEllipse(new Rectangle(100, 200, 500, 200));
    foreach (PointF point in path.PathPoints)
    {
        pictureBox1.Location = Point.Round(point);
        Thread.Sleep(100); // just for the demonstration
    }
