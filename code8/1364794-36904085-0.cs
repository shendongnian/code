    public struct IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static IntVector2 operator +(IntVector2 value1, IntVector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }
        public override int GetHashCode()
        {
            //overrode this to get rid of warning
            return base.GetHashCode();
        }
        //This equals get's called, notice the override keyword
        public override bool Equals(object obj)
        {
            if (obj is IntVector2)
            {
                IntVector2 vObj = (IntVector2)obj;
                return vObj.X == this.X && vObj.Y == this.Y;           
            }
            return false;
        }
        //This won't get called, it's not part of the framework, this is adding a new overload for equals that .Net won't know about.
        public bool Equals(IntVector2 other)
        {
            return (X == other.X) && (Y == other.Y);
        }
        public override string ToString()
        {
            return string.Format("{ value1: {0}, value2: {0} }", X, Y);
        }
    }
