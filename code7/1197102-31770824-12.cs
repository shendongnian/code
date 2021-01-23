    public class Product
        {
            [Key]
            public int ProductId { get; set; }
    
            public int? ParentProductId { get; set; }
    
            public virtual Product ParentProduct { get; set; }
        }
