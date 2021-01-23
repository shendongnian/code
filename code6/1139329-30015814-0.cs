    class Order
    {
       [Key]
       public int Id { get; set }
    
       public virtual List<OrderItem> Items { get; set; }
    
       public Order()
       {
         Items = new List<OrderItem>();
       }
    }
    
    class OrderItem
    {
       [Key]
       public int Id { get; set; }
    
       public string ItemName { get; set; } //of course just a demo property
    }
