    public class Player
    {
        [InverseProperty("Player")]
        public virtual ICollection<FriendLinker> Players { get; set; }
    
        [InverseProperty("Friend")]
        public virtual ICollection<FriendLinker> Friends { get; set; }
    
        [Required]
        public string Password { get; set; } //Will be switched to byte[] for hash
    
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
    }
