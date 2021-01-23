    public class Person
    {
        public int Id { get; set; }
    
        [Required]
        [Index("IX_Person_PersonCategory", 1, IsUnique = true)]
        [MaxLength(100)]
        public string ExternalId { get; set; }
    
        [Index("IX_Person_PersonCategory", 2, IsUnique = true)]
        public int CategoryId { get; set; }
        public PersonCategory Category { get; set; }
    
        ...
    }
