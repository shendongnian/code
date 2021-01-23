    public class SubEntityComparer : IEqualityComparer<SubEntity>
    {
        public bool Equals(SubEntity x, SubEntity y)
        {
            if (x == null ^ y == null)
                return false;
            if (ReferenceEquals(x, y))
                return true;
            return x.Field1 == y.Field1 &&
                   x.Field2 == y.Field2;
        }
        public int GetHashCode(SubEntity obj)
        {
            return obj.Field1.GetHashCode() + 37 * obj.Field2.GetHashCode();
        }
    }
