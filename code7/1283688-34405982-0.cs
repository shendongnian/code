    public class Order
    {
        [Key]
        public int ID { get; set;}
    
        public string Name { get; set; }
        public int ConsumerId { get; set; }
        public virtual Consumer Consumer { get; set; }
    }
    
    public class Consumer
    {
        public Consumer()
        {
            this.Orders = new HashSet<Order>();
        }
        public virtual List<Order> Orders { get; set;}
    }
