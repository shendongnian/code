    public class Box : IEquatable<Box>
    {
        double height, length, breadth;
        public static bool operator ==(Box obj1, Box obj2)
        {
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }
            return (obj1.length == obj2.length
                        && obj1.breadth == obj2.breadth
                        && obj1.height == obj2.height);
        }
        public static bool operator !=(Box obj1, Box obj2)
        {
            return !(obj1 == obj2);
        }
        public bool Equals(Box other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return height.Equals(other.height) 
                   && length.Equals(other.length)
                   && breadth.Equals(other.breadth);
        }
    }
