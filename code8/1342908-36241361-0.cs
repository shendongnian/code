    /// <summary>
    /// this holds all the standard auditing information.  Any EF table 
    /// with a UI should extend this class
    /// </summary>
    public abstract class AuditableTable
    {
        [Required]
        [MaxLength(789)]
        public string CreatedBy { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        [MaxLength(789)]
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
