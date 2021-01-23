    static void Main(string[] args)
    {
        List<Point> Points1 = new List<Point>();
        //Points1.Add(); assign your series points
        List<Point> Points2 = new List<Point>();
        //Points2.Add(); assign your series points
        Series Series1 = new Series(Points1);
        Series Series2 = new Series(Points2);
        var betweenArea = Math.Abs(Series1.Area() - Series2.Area());
    }
    public class Series
    {
        
        List<Point> Points { get; set; }
        public Series(List<Point> points)
        {
            Points = points;
        }
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
