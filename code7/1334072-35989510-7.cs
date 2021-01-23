    public class MyEqualityComparer : IEqualityComparer<Category>
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
