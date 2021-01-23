    public class Stock
    {
        [PrimaryKey]
        public string UUID { get; set; } 
        [MaxLength(8)]
        public string Symbol { get; set; }
    
        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Valuation> Valuations { get; set; }
    }
