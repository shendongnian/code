    public class Orders
    {
        [key]
        public int OrderId {get;set;}
        public virtual ICollection<Products> Product { get; set; }
    }
    public class Product
    {
        [key]
        public int ProductId {get;set;}
        [ForeignKey]
        public OrderId {get;set;}
        public virtual Orders Order {get;set;}
    }
