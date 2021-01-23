    public class User
        {
            public int UserID { get; set; }
            // No separate Administrator class required
            public bool IsAdministrator { get; set; }
    
            public virtual ICollection<Ticket> Tickets { get; set; }
        }
    public class Ticket
    {
        public int TicketID { get; set; }
    
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    
        // This "Administrator" is a User with IsAdministrator = true
        // A Ticket may or may not have an Administrator hence it is nullable.
        public int? AdministratorID { get; set; }
        [ForeignKey("UserID")]
        public virtual User Administrator { get; set; }
    }
