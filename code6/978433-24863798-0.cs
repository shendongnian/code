    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item lhs, Item rhs)
        {
            return lhs.Year == rhs.Year && lhs.QuarterIndex == rhs.QuarterIndex;
        }
        public int GetHashCode(Item item)
        {
            unchecked
            {
                int hash = 23;
                hash = (hash * 31) + item.Year.GetHashCode();
                hash = (hash * 31) + item.QuarterIndex;
                return hash;
            }
        }
    }
