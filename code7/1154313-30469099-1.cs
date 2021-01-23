    public class MyPointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            return p1 == p2; // defer to Point's existing operator==
        }
        public int GetHashCode(Point obj)
        {
            return /* your favorite hashcode function here */;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create hashset with custom hashcode algorithm
            HashSet<Point> myHashSet = new HashSet<Point>(new MyPointEqualityComparer());
            // Same thing also works for dictionary
            Dictionary<Point, string> myDictionary = new Dictionary<Point, string>(new MyPointEqualityComparer());
        }
    }
