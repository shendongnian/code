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
        // this is second one '!='
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
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == GetType() && Equals((Box)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = height.GetHashCode();
                hashCode = (hashCode * 397) ^ length.GetHashCode();
                hashCode = (hashCode * 397) ^ breadth.GetHashCode();
                return hashCode;
            }
        }
    }
