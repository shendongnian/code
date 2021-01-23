    public class Triangle {
        public Point Point1 {get;}
        public Point Point2 {get;}
        public Point Point3 {get;}
        public triangle(Point point1, Point point2, Point point3) {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
        public static Triangle Parse(string str) {
            if (str == null) {
                throw new ArgumentNullException(nameof(str));
            }
            var tok = str.Split(' ');
            if (tok.Length != 6) {
                throw new ArgumentException(nameof(str));
            }
            return new Triangle(
                new Point(int.Parse(tok[0]), int.Parse(tok[1]))
            ,   new Point(int.Parse(tok[2]), int.Parse(tok[3]))
            ,   new Point(int.Parse(tok[4]), int.Parse(tok[5]))
            );
        }
    }
