    public class Point
    {
        public Distance X { get; private set; }
        public Distance Y { get; private set; }
        public Distance Z { get; private set; }
        public int DatabaseId { get; private set; } // DatabaseId can't be set publicly
        private Point() { } // Parameterless constructor for EntityFramework
        public Point(Distance x, Distance y, Distance z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
