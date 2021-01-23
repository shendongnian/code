    public class DomainEntity : .....
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastUpdatedBy { get; set; }
    }
