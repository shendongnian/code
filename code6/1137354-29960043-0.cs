    public class Category
    {
        // Scalar properties here
    
        // This navigation property describes "categories-products" hierarchy
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class Supplier
    {
        // Scalar properties here
    }
    
    public class Product
    {
        // Scalar properties here
    
        // This navigation property describes "categories-products" hierarchy
        public int CategoryId { get; set; }         
        public virtual Category Category { get; set; }
    }
    
    // This entity describes products, that were supplied by any supplier.
    // Note, that we don't need category here, because it can be received through Product.Category reference
    public class SuppliedProduct
    {
        public int Id { get; set; }
        public DateTime WhenSupplied { get; set; }
        public decimal Quantity { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }
    }
