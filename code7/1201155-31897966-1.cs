    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public override string ToString()
        {
            return string.Format("[ x={0}, y={1}, z={2} ]", X, Y, Z);
        }
    }
