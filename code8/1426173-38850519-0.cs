    public class List : Entity<int>
    {
        public int CategoryId { get; set; }
    
        [ForeignKey("CategoryId")
        public Category Category { get; set; } 
    }
