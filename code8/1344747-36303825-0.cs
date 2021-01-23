    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
    }
