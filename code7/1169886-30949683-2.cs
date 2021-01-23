    public class UserEvent
    {
        [Key,Column(Order=0)]
        public string UserId { get; set; }
    
        [Key,Column(Order=1)]
        public int EventId { get; set; }
    
        public DateTime EnrolTime { get; set; }
    
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
