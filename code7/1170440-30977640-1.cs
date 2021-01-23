    class Line
    {
        public Point BottomRight { get; set; }
        public Point Origin { get; set; }
        public Line(Point pointA, Point pointB)
        {
            Origin = pointA;
            BottomRight = pointB;
        }
    }
