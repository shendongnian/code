    public class BookingInformation
    {
        public string booking_id { get; set; }
        public ToLocation to_location { get; set; }
        public string notes { get; set; }
        public BookingInformation()
        {
            to_location = new ToLocation();
        }
    }
    public class ToLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Address2 address { get; set; }
        public object comment { get; set; }
        public object airport { get; set; }
        public ToLocation()
        {
            address = new Address2();
        }
    }
