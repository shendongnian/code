    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; } // <-- for your dropdown
    }
