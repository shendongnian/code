    public class ProductionOrder
    {
        public int Id { get; set; }
        public Product Product { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public IList<ProductPart> ProductParts { get; set; }
    }
    public class ProductPart
    {
        public int Id { get; set; }
        public Product ContainingProduct { get; set; }
    }
