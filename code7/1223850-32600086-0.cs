    XGraphicsPath path = new XGraphicsPath();
        XFont font = new XFont(text.Font, XUnit.FromMillimeter(text.Height), XFontStyle.Regular);
        //path.AddString with my string details
                    
        PointF[] points = path.Internals.GdiPath.PathPoints;
    
        foreach (PointF point in points)
        {
            //Get leftmost point x value
            if (minX == null || point.X < minX)
            {   
                minX = point.X;
            }
        
            //Get top most point y value
            if (minY == null || point.Y < minY)
            {
                minY = point.Y;
            }
        
            //Get top most point y value
            if (maxX == null || point.X > maxX)
            {
                maxX = point.X;
            }
        
            //Get bottom most point y value
            if (maxY == null || point.Y > maxY)
            {
                maxY = point.Y;
            }
        }
