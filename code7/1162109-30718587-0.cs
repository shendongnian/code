    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [InverseProperty("ReceiverId")]
        public virtual ICollection<Friendship> FriendshipsIncoming { get; set; }
        [InverseProperty("SenderId")]
        public virtual ICollection<Friendship> FriendshipsOutgoing { get; set; }
    }
	public class Friendship
	{
		public int FriendshipId { get; set; }
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		[ForeignKey("SenderId")]
		public Player Sender { get; set; }
		[ForeignKey("ReceiverId")]
		public Player Receiver { get; set; }
		[Required]
		public bool Confirmed { get; set; }
	}
