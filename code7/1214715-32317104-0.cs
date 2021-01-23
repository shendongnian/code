    public class SomeClassComparer : IEqualityComparer<SomeClass>
    {
        public bool Equals(SomeClass x, SomeClass y)
        {
            return x.Name == y.Name && x.Class == y.Class && x.Roll == y.Roll;
        }
        public int GetHashCode(SomeClass obj)
        {
            return (obj.Name + obj.Class).GetHashCode();
        }
    }
