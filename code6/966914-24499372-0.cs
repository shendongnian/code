    public class Product
    {
        public int ID              { get; set; }
        public string Manufacturer { get; set; }
        public string Model        { get; set; }
        public string PartNumber   { get; set; }
        public int CategoryID      { get; set; }
        public string Description  { get; set; }
        public int VerticalID = 1;
        private ProductPrice _price;
        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<ProductDocument> Documents { get; set; }
        public virtual ICollection<ProductDetail> Details { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProducts { get; set; }
        // Lazy Loading
        public ProductPrice Price
        {
            get
            {
                if (_price == null)
                {
                    var db = new ApplicationContext();
                    _price = db.Prices.FirstOrDefault(p => p.ProductID == ID && p.VerticalID == VerticalID);
                }
                
                return _price;
            }
        }
    }
