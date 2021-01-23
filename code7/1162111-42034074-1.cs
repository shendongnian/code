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
