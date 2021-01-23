    public class Booking
    {
        // Your current code and... 
        // If you want One to One:
        public virtual Booking RelatedBooking { get; set; }
        // but if it's One to Many:
        public virtual ICollection<Booking> RelaitedBookings { get; set; }
    }
