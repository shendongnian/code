    public class TrisCoordinates : IComparable<TrisCoordinates>
    {
        private float x;
        private float y;
        private float z;
        public TrisCoordinates(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public float GetZ()
        {
            return z;
        }
        public int CompareTo(TrisCoordinates other)
        {
            return (x + y + z).CompareTo(other.x + other.y + other.z);
        }
    }
