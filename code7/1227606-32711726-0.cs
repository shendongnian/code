    public class MembershipClientValidationModel
    {
        [Key]
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipExpiryDate { get; set; }
        public bool IsMembershipValid { get; set; }
        [Required]
        public virtual ClientModel Client { get; set; }
    }
