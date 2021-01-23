    public class EventUserDetail
    {
        [Key]
        public int Id { get; set; }
        public bool Invited { get; set; }
        public DateTime? InviteDate { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
