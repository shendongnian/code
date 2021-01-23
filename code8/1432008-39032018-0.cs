	public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole,
    CustomUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        public ApplicationUser()
        {
            SentFriendRequests = new List<Friend>();
            ReceievedFriendRequests = new List<Friend>();
        }
        [Required]
        public string Alias { get; set; }
        public string Name { get; set; }
        public byte[] ProfilePicture { get; set; }
        public virtual ICollection<Friend> SentFriendRequests { get; set; }
        public virtual ICollection<Friend> ReceievedFriendRequests { get; set; }
        [NotMapped]
        public virtual ICollection<Friend> Friends {
            get
            {
                var friends = SentFriendRequests.Where(x => x.Approved).ToList();
                friends.AddRange(ReceievedFriendRequests.Where(x => x.Approved));
                return friends;
            } }
    }
	
	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        modelBuilder.Entity<Friend>()
            .HasRequired(a => a.RequestedBy)
            .WithMany(b => b.SentFriendRequests)
            .HasForeignKey(c => c.RequestedById);
        modelBuilder.Entity<Friend>()
            .HasRequired(a => a.RequestedTo)
            .WithMany(b => b.ReceievedFriendRequests)
            .HasForeignKey(c => c.RequestedToId);
    }
	
	public class Friend
    {
        [Key, Column(Order = 0)]
        public int RequestedById { get; set; } 
        [Key, Column(Order = 1)]
        public int RequestedToId { get; set; } 
        public virtual ApplicationUser RequestedBy { get; set; }
        public virtual ApplicationUser RequestedTo { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? BecameFriendsTime { get; set; }
        public FriendRequestFlag FriendRequestFlag { get; set; }
        [NotMapped]
        public bool Approved => FriendRequestFlag == FriendRequestFlag.Approved;
        public void AddFriendRequest(ApplicationUser user, ApplicationUser friendUser)
        {
            var friendRequest = new Friend()
            {
                RequestedBy = user,
                RequestedTo = friendUser,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.None
            };
            user.SentFriendRequests.Add(friendRequest);
        }
    }
    public enum FriendRequestFlag
    {
        None,
        Approved,
        Rejected,
        Blocked,
        Spam
    };
