       public int PlayerId { get; set; }
   
       [Required]
       public string Name { get; set; }
   
       [Required]
       public string Email { get; set; }
   
       [InverseProperty("Receiver")]
       public virtual ICollection<Friendship> FriendshipsIncoming { get; set; }
   
       [InverseProperty("Sender")]
       public virtual ICollection<Friendship> FriendshipsOutgoing { get; set; }
