    public class Order
    {
        [Key]
        public int ID { get; set;}
    
        public string Name { get; set; }
    
        public int? ParentOrderId{ get; set; }
    
        public virtual Order ParentOrder { get; set; }
        public virtual ICollection<Order> ChildOrders { get; set; }
    }
