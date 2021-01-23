    public class Lead {
        public int Id { get; set; }
        public virtual Work Work { get; set; }
    }
    
    public class Work {
        [Key, ForeignKey("Lead")]
        public int Id { get; set; }
        public virtual Lead Lead { get; set; }
    }
