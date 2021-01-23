    public class Product 
    { 
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; } 
    } 
    public class ProductViewModel
    {
        public List<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product{ ProductId = 1, Name = "Product_1" },
                    new Product{ ProductId = 2, Name = "Product_2" }
                };
            }
        }
    }
    //Following code can be placed in the Loaded event of the page:
    DataContext = new ProductViewModel();
