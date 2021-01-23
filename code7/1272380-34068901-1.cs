    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            return p1.x==p2.x && p1.y == p2.y;
        }
        public int GetHashCode(Point p1)
        {
            return p1.x*p2.x;//bla bla
        }
    }
