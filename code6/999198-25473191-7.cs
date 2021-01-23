    public static class XYZProxyExtensions
    {
        public static XYZProxy ToXYZProxy(this XYZ xyz)
        {
            return new XYZProxy(xyz.X, xyz.Y, xyz.Z);
        }
    }
    public class XYZProxy
    {
        public XYZProxy()
        {
            this.X = this.Y = this.Z = 0;
        }
        public XYZProxy(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public XYZ ToXYZ()
        {
            return new XYZ(X, Y, Z);
        }
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
