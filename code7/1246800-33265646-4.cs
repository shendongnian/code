    public class ProductPlus
    {
        public ProductPlus() { }
        public ProductPlus(Product p){
            SomeProduct = p;
        }
        public Product SomeProduct { get; set; }
        public bool Restock { get; set; }
        public DateTime? DateSold { get; set; }        
    }
