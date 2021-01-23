    public class XElComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            return x.Value.Equals(y.Value);
        }
        public int GetHashCode(XElement obj)
        {
            if (obj == null) return 0;
            return obj.Value.GetHashCode();
        }
    }
