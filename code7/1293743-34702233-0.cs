    public class ProductList : ...
    {
        public ICollection<Country> Countries { get; set; }
    }
    
    public class Country : ...
    {
        public ICollection<ProductListing> ProductListings { get; set; }
    }
