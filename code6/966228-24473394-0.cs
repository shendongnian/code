    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual TimeZone TimeZone { get; set; }
    }
    [Table("TimeZone")]
    public class TimeZone
    {
        [Key]
        public int Id { get; set; }
    
        [StringLength(255)]
        public string Name { get; set; }
    
    }
