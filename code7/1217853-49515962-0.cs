    public class Point
    {
        [Obsolete("For ORM(EF) use only", true)]
        public Point() { }
        public Point(Distance x, Distance y, Distance z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        
        public int Id { get; set; }
        public Distance X { get => _x; }
        private Distance _x;
        public Distance Y { get => _y; }
        private Distance _y;
        public Distance Z { get => _z; }
        private Distance _z;
    }
