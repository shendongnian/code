    using System.ComponentModel.DataAnnotations;
    
    public class ProductModel
    {
        public ProductModel(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
    
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        [Required]
        public string Category { get; set; }
    
        [Required]
        public decimal Price { get; set; }
    }
