    List<PointF> Intersections(PointF cc, float r, PointF p1, PointF p2)
    {
        float m = 0; float c = 0;
        if (p1.X == p2.X) { m = float.PositiveInfinity; c = p1.X; }
        else              { m = (p2.Y - p1.Y) / (p2.X - p1.X); c = p1.Y * p1.Y / p2.Y; }
        return Intersections(cc, r, m, c);
    }
