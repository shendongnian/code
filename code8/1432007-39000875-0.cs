    public class ApplicationUser
        {
            [Key]
            public virtual int Id { get; set; }
            public ApplicationUser()
            {
                Friends = new List<Friend>();
            }
            [Required]
            public string Alias { get; set; }
    
            [ForeignKey("RequestedBy_Id")]
            public virtual ICollection<Friend> Friends { get; set; }
        }
    
        public class Friend
        {
            public virtual int Id { get; set; }
    
            [ForeignKey("RequestedBy")]
            public virtual int RequestedBy_Id { get; set; }
            public virtual ApplicationUser RequestedBy { get; set; }
    
            public virtual ApplicationUser RequestedTo { get; set; }
    
            public DateTime? RequestTime { get; set; }
    
            public FriendRequestFlag FriendRequestFlag { get; set; }
        }
    
        public enum FriendRequestFlag
        {
            None,
            Approved,
            Rejected,
            Blocked,
            Spam
        };
