    public class Ticket
    {
        public int TicketID { get; set; }
    
        //For Ticket to User relationship many to 1
        public int UserID { get; set; }
        public virtual User User { get; set; }
        //For Administrator to Ticket 1 to many relationship
        public int? Administrator{ get; set; }
        public virtual User Administrator { get; set; }
