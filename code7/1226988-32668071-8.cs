    public class Item
    {
        public int ItemId { get; set; }
            
        public virtual ICollection<Item> AssociatedItems { get; set; }
        public virtual ICollection<Item> ItemsAssociatedThisItem { get; set; }
    }
