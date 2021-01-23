    public class TrisCoordinates : IComparable<TrisCoordinates>
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public TrisCoordinates(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int CompareTo(TrisCoordinates otherCoordinates)
        {
            if (X > otherCoordinates.X)
                return 1;
            if (X < otherCoordinates.X)
                return -1;
            if (Y > otherCoordinates.Y)
                return 1;
            if (Y < otherCoordinates.Y)
                return -1;
            if (Z > otherCoordinates.Z)
                return 1;
            if (Z < otherCoordinates.Z)
                return -1;
            return 0;
        }
    }
