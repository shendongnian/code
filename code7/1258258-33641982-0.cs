    public class MyEqualityComparer : IEqualityComparer<SomeType>
    {
        public bool Equals(SomeType x, SomeType y)
        {
            return (x.Application == y.Application && x.ExternalID == y.ExternalID)
                   ||
                   (x.Application == y.Application && x.ExternalDisplayId == y.ExternalDisplayId);
        }
        public int GetHashCode(SomeType obj)
        {
            return (obj.Application + obj.ExternalDisplayId + obj.ExternalID).GetHashCode();
        }
    }
