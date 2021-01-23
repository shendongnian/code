    [Table(Name = "Orders")]
    class Order
    {
         [Column(Storage="Price", DbType="Money",Expression="UnitPrice + 1.00")]
         public decimal Price{ get; set }
    
         [Column(Storage="Qty", DbType="Int"]
         public int Quantity { get; set; }
    
         [Column(Storage="Total", DbType="Money",Expression="Price * Quantity")]
         public decimal Total { get; set; }
    }
