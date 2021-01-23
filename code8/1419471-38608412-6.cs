    public class Point : Vector
    {
        public Point(double x, double y, double z) : base(x, y, z) { }
    
        public Point Clone()
        {
            return new Point(this.x, this.y, this.z);
        }
    
        public Point Scale(double sc)
        {
            return (Point)base.Scale(sc);
        }
    }
