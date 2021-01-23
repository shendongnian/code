    public class Comparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.ItemParentId != y.ItemParentId;
        }
    
        public int GetHashCode(Item obj)
        { 
            // You *should* move this into Item.GetHashCode...
            return obj.ItemParentId * 37;
        }
    }
