    public class UserProfile
    {
        [Key, ForeignKey("UserAccount")]
        public int UserProfileId { get; set; }
    
        public UserAccount UserAccount{ get; set; }
        [ForeignKey("ApprovedBy")]
        public int? ApprovedById { get; set; }
        public virtual UserAccount ApprovedBy { get; set; }
    }
