    public class Ticket {
        //....code removed for brevity
        public string UserID { get; set; } // fixed
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; } // fixed
    }
