    public class Ticket
    {
        public int TicketID { get; set; }
        public string Issue { get; set; }
        [DisplayFormat(NullDisplayText = "No Priority")]
        public Priority? Priority { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("AdminID")]
        public Administrator Admin { get; set; }
        public int AdminID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public int UserID { get; set; }    
    }
