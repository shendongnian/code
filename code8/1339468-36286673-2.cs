    public class Product
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
