    //EF Generated
    public partial class Product
    {
    }
    //Custom class
    public partial class Product
    {
        // The framework will create this constructor any time a change to 
        // the edmx file is made. This means any "custom" statements will 
        // be overridden and have to be re-entered
        public Product()
        {
            this.PageToProduct = new HashSet<PageToProduct>();
            this.ProductRates = new HashSet<ProductRates>();
            this.ProductToRider = new HashSet<ProductToRider>();
        }
