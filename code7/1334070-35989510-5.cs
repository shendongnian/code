    public class MyEqualityComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Category obj)
        {
            return obj.Name;
        }
    }
