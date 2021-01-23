    public class Item
    {
        public int Year { get; set; }
        public int QuarterIndex { get; set; }
        public override bool Equals(object otherItem)
        {
            Item other = otherItem as Item;
            if (other == null) return false;
            return this.Equals(other);
        }
        public bool Equals(Item otherItem)
        {
            if(otherItem == null) return false;
            return Year == otherItem.Year && QuarterIndex == otherItem.QuarterIndex;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = (hash * 31) + Year;
                hash = (hash * 31) + QuarterIndex;
                return hash;
            }
        }
    }
