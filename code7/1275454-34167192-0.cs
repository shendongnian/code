    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
    
    public class Cart
    {
        public int Id { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
    
    public class CartItem
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        
        public int NrOfItems { get; set; }
    }
