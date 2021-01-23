    public class MyEqualityComparer1 : IEqualityComparer<SomeType>
    {
        public bool Equals(SomeType x, SomeType y)
        {
            return x.Application == y.Application && x.ExternalID == y.ExternalID;
        }
        public int GetHashCode(SomeType obj)
        {
            return (obj.Application + obj.ExternalID).GetHashCode();
        }
    }
    public class MyEqualityComparer2 : IEqualityComparer<SomeType>
    {
        public bool Equals(SomeType x, SomeType y)
        {
            return x.Application == y.Application && x.ExternalDisplayId == y.ExternalDisplayId;
        }
        public int GetHashCode(SomeType obj)
        {
            return (obj.Application + obj.ExternalDisplayId).GetHashCode();
        }
    }
