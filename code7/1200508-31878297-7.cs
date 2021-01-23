    public class Comparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.ItemParentId == y.ItemParentId 
                || x.Name == y.Name;
        }
    
        public int GetHashCode(Item obj)
        {
            return obj.ItemParentId.GetHashCode() + obj.Name.GetHashCode();
        }
    }
