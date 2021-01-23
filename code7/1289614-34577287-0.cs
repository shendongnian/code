    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Order MostRecentOrder { get; set; }
    }
