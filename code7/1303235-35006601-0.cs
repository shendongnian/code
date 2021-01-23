    public class ItemGridViewModel
    {
        // Your implementation
    }
    public class ItemGridViewModelEqualityComparer : IEqualityComparer<ItemGridViewModel> 
    {
        public bool Equals(ItemGridViewModel a, ItemGridViewModel b)
        {
            return a.ItemID == b.ItemID;
        }
        public int GetHashCode(ItemGridViewModel o)
        {
            return o.ItemID.GetHashCode();
        }
    }
