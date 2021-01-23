    public class ItemComparer: IEqualityComparer<Item>
    {
        public bool Equals(Item i1, Item i2)
        {
            if(i1 == null && i2 == null) return true;
            if(i1 == null ^ i2 ==null) return false;
            return(i1 == i2 || i1.Id == i2.Id);
        }
        public int GetHashCode(Item item)
        {
            return item != null ? item.Id.GetHashcode() : 0;
        }
    }
