    public class UserEvent
    {
        public DateTime EnrolTime { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
