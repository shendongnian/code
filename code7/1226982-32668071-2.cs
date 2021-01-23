    public class Item
    {
        public virtual ICollection<ItemAssociation> AssociatedItems { get; set; }
        public virtual ICollection<ItemAssociation> ItemsAssociatedThisItem { get; set; }
    }
    public class ItemAssociation
    {
        public int ItemId { get; set; }
    
        public int ItemAssociatedId { get; set; }
    
        public virtual Item Item { get; set; }
    
        public virtual Item ItemAssociated { get; set; }
    }
