    public class CategoryComparer: IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            if (x == null && y == null)
                return true;
            if (x == null)
                return false;
            if (y == null)
                return false;
            return x.CategoryId.GetHashCode() == y.CategoryId.GetHashCode();
        }
        public int GetHashCode(Category obj)
        {
            return obj.CategoryId.GetHashCode();
        }
    }
