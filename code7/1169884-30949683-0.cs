    public class UserEvent
    {
        [Column(Order=0), Key, ForeignKey("User")]
        public string UserId { get; set; }
    
        [Column(Order=1), Key, ForeignKey("Event")]
        public int EventId { get; set; }
    
        public DateTime EnrolTime { get; set; }
    
        public virtual AspNetUser User { get; set; }
        public virtual Event Event { get; set; }
    }
