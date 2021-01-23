    public class Comparer : IEqualityComparer<ComplexType>
    {
        public bool Equals(ComplexType x, ComplexType y)
        {
            // code to check your complex type for equality
        }
        public int GetHashCode(ComplexType obj)
        {
            return obj.GetHashCode();
        }
    }
