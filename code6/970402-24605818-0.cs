    public class Category
    {
        public Category()
        {
            this.Products = new ObservableCollection<Product>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ObservableCollection<Product> Products { get; private set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
