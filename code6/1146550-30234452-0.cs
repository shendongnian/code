    public class Country
    {
        [Key]
        public int Sid { get; set; }
    
        public string ObjectId { get; set; }
    
        [ForeignKey("ObjectId")]
        public virtual ICollection<Heading> Headings { get; set; }
    
        ...
    }
    
    public class Heading
    {
        public int Id { get; set; }
    
        [Key]
        public string ObjectId { get; set; }
    }
