    public class Compare : IEqualityComparer<Part>
    {
        public bool Equals(Part x, Part y)
        {
            return x.SomeProperty == y.SomeProperty;
        }
        public int GetHashCode(Part part)
        {
            return part.SomeProperty.GetHashCode();
        }
    }
