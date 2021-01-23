    public class Rootobject
    {
        public int AppointmentId { get; set; }
        public Manageaptarray[] manageaptarray { get; set; }
    }
    public class Manageaptarray
    {
        public int VanId { get; set; }
        public Doctor[] Doctors { get; set; }
    }
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
