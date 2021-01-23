    public partial class Point
    {
        public static int CalculateDistance(Point p0, Point p1)
        {
            return Math.Max(
                Math.Abs(p0.X - p1.X),
                Math.Abs(p0.Y - p1.Y)
                );
        }
    }
    
    public static class PointExtensions
    {
        public static int GetTotalCost(this IEnumerable<Point> source)
        {
            return source
                .Zip(source.Skip(1), Point.CalculateDistance)
                .Sum();
        }
    }
