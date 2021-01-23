    static void Main(string[] args)
    {
        Series Series1 = new Series();
        Series Series2 = new Series();
        var betweenArea = Math.Abs(Series1.Area() - Series2.Area());
    }
    public class Series
    {
        List<Point> Points { get; set; }
        public double Area()
        {
            double Area = 0;
            var points = Points.OrderBy(P => P.X).ToList();
            for (int i = 0; i < points.Count - 1; i++)
            {
                Point Point1;
                Point Point2;
                if (points[i].Y < points[i + 1].Y)
                {
                    Point1 = points[i];
                    Point2 = points[i + 1];
                }
                else
                 {
                     Point1 = points[i + 1];
                     Point2 = points[i];
                 }
                 Area += Point1.Y * (Math.Abs(Point1.X - Point2.X));
                Area += ((Math.Abs(Point1.Y - Point2.Y)) * (Math.Abs(Point1.X - Point2.X)))/2;
            }
            return Area;
        }
    }
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
