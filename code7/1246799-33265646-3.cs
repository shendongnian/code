    public class ProductPlus
    {
        public ProductPlus() { }
        public ProductPlus(product p){
            Product = p;
        }
        public product Product { get; set; }
        public bool Restock { get; set; }
        public DateTime? DateSold { get; set; }        
    }
