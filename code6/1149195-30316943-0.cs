    public class Enrollment
    {
        public int Id { get; set; }
        [Required]
        // The default column is a string, although it stores a Guid
        public string UserId { get; set; } 
        // If specified, should refer to the field name on this side of the relationship
        // As Pengivan stated, not needed unless there are multiple references.
        [ForeignKey("UserId")] 
        public virtual ApplicationUser User { get; set; }
        [Required]
        public int MajorId { get; set; }
        public virtual Major Major { get; set; }
        [Required]
        public int TermId { get; set; }
        public virtual Term Term { get; set; }
    }
