    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set;}
        public decimal Price { get; set; }
        
        public Category Category { get; set; } // <--- Add this
        public virtual ICollection<Category> Categories { get; set; }
    }
