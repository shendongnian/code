    //using System.Drawing;
    //using System.Drawing.Drawing2D;
    bool IsOnLine(Point p1, Point p2, Point p, int width = 1)
    {
        using (var path = new GraphicsPath())
        {
            using (var pen = new Pen(Brushes.Black, width))
            {
                path.AddLine(p1, p2);
                return path.IsOutlineVisible(p, pen);
            }
        }
    }
