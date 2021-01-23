    class Categorization
    {
        public int ProductId { get; set; }
      [JsonIgnore]
       public Product Product { get; set; }
    
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
