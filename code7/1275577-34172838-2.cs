    bool IsOnLine(Point p1, Point p2, Point p, int width = 1)
    {
        var isOnLine= false;
        using (var path = new GraphicsPath())
        {
            using (var pen = new Pen(Brushes.Black, width))
            {
                path.AddLine(p1,p2);
                isOnLine = path.IsOutlineVisible(p, pen);
            }
        }
        return isOnLine;
    }
