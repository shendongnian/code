    public class Comparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.ItemParentId == y.ItemParentId 
                || x.Name == y.Name;
        }
    
        public int GetHashCode(Item obj)
        {
            int hash = 17;
            hash = hash * 23 + obj.ItemParentId.GetHashCode();
            hash = hash * 23 + obj.Name.GetHashCode();
            return hash;
        }
    }
