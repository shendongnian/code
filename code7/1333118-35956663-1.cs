    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        protected bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) * Y.GetHashCode();
            }
        }
        public static bool operator ==(Point left, Point right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Point left, Point right)
        {
            return !Equals(left, right);
        }
    }
    public class Line
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        protected bool Equals(Line other)
        {
            return Equals(Point1, other.Point1) && Equals(Point2, other.Point2) 
                 || Equals(Point1, other.Point2) && Equals(Point2, other.Point1);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var orderedPoints =
                    new[] {Point1, Point2}.OrderBy(p => p != null ? p.X : 0)
                                          .ThenBy(p => p != null ? p.Y : 0).ToList();
                var p1 = orderedPoints[0];
                var p2 = orderedPoints[1];
                return ((p1 != null ? p1.GetHashCode() : 0)*397) 
                       * (p2 != null ? p2.GetHashCode() : 0);
            }
        }
        public static bool operator ==(Line left, Line right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Line left, Line right)
        {
            return !Equals(left, right);
        }
    }
