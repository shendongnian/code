    Point A = new Point(200, 200); // *
    Point B = new Point(500, 250);
    int smallSize = 50;
    void doTheDraw(PictureBox pb)
    {
        Bitmap bmp = new Bitmap(pb.Width, pb.Height);
        float angle = -(float)(Math.Atan2(A.Y - B.Y, B.X - A.X) * 180f / Math.PI);
        int longSide = (int)(Math.Sqrt((A.Y - B.Y) * (A.Y - B.Y) + (B.X - A.X) * (B.X - A.X)));
        Point C = new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
        Size size = new System.Drawing.Size((int)longSide, smallSize);
        using (Pen pen = new Pen(Color.Orange, 3f))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            // a nice background grid (optional):
            DrawGrid(g, 0, 0, 100, 50, 10,
                Color.LightSlateGray, Color.DarkGray, Color.Gainsboro);
            // show the points we use (optional):
            g.FillEllipse(Brushes.Red, A.X - 4, A.Y - 4, 8, 8);
            g.FillRectangle(Brushes.Red, B.X - 3, B.Y - 3, 7, 7);
            g.FillEllipse(Brushes.Red, C.X - 5, C.Y - 5, 11, 11);
            // show the connection line (optional):
            g.DrawLine(Pens.Orange, A, B);
            // here comes the ellipse:
            DrawEllipse(g, pen, C, size, angle);
        }
        pb.Image = bmp;
    }
