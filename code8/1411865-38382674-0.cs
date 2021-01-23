    public class ApplicationUser : IdentityUser{
      [Required]
      [StringLength(100)]
      public string Name { get; set; }
      public Following Follower { get; set; }
    }
    
    public class Following{
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }
        public ICollection<ApplicationUser> Followers { get; set; }
    }
