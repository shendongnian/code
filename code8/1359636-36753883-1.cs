    public class Event
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //public Guid CategoryId { get; set; }
       
        [Required]
        //[ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    
    }
