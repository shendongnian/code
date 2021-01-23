    public static bool IsInPolygon(Point[] poly, Point clickedPoint)
    {
        if (poly.Length < 3)
        {
            return false;
        }
    
        Point p1, p2;
    
        bool inside = false;
    
        Point oldPoint = new Point(poly[poly.Length - 1].X, poly[poly.Length - 1].Y);
            
        for (int i = 0; i < poly.Length; i++)
        {
            Point newPoint = new Point(poly[i].X, poly[i].Y);
                
            if (newPoint.X > oldPoint.X)
            {
                p1 = oldPoint;
                p2 = newPoint;
            }
            else
            {
                p1 = newPoint;
                p2 = oldPoint;
            }
    
            if ((newPoint.X < clickedPoint.X) == (clickedPoint.X <= oldPoint.X)
                && (clickedPoint.Y - (long)p1.Y) * (p2.X - p1.X) < (p2.Y - (long)p1.Y) *(clickedPoint.X - p1.X))
            {
                inside = !inside;
            }
    
            oldPoint = newPoint;
        }
    
        return inside;
    }
