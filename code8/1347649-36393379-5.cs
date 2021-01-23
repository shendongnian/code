    public class Ticket
    {
        public int? TicketID { get; set; }
        public int UserID { get; set; }
        public int IssuedID { get; set; }
    
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    
        [ForeignKey("IssuedID")]
        public virtual ApplicationUser IssuedUser { get; set; }
    }
