    public class ClinicianAvailability
    {
        public int ClinicianAvailabilityId { get; set; }
    }
    public class SurgicalBooking
    {
        public int SurgicalBookingId { get; set; }
        public bool IsAdhoc { get; set; }
        public virtual ClinicianAvailability ClinicianAvailability { get; set; }
    }
    public class TheatreBooking
    {
        public int TheatreBookingId { get; set; }
        public virtual SurgicalBooking SurgicalBooking { get; set; }
        public virtual ClinicianAvailability ClinicianAvailability { get; private set; }
    }
