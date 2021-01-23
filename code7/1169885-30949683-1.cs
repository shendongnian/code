    public class UserEvent
    {
        [ Key,Column(Order=0), ForeignKey("User")]
        public string UserId { get; set; }
    
        [ Key,Column(Order=1), ForeignKey("Event")]
        public int EventId { get; set; }
    
        public DateTime EnrolTime { get; set; }
    
        public virtual AspNetUser User { get; set; }
        public virtual Event Event { get; set; }
    }
