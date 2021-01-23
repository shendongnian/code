    public class Triangle
    {
        public virtual int NumSides { get { return 3; } }
        int sideLength;
    
        public int Perimeter()
        {
            return NumSides * sideLength;
        }
    }
    
    public class Square : Triangle
    {
        public override int NumSides { get { return 4; } }
    }
