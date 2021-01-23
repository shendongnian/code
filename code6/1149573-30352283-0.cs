    public class OrderDetail
        {
          //  public long OrderDetailId { get; set; }
    
             [Key, Column(Order = 1)]
            public int OrderId { get; set; }
    
            [Key, Column(Order = 2)]
            public int RowNumber { get; set; }
    
            [ForeignKey("Product")]
            public int ProductId { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            [ForeignKey("ProductId")]
            public virtual Product Product { get; set; }
            public virtual Order Order { get; set; }
    
        }
