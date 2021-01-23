    public class Patient : ApplicationUser
    {
        // patient-specific properties
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
    public class Doctor : ApplicationUser
    {
        // doctor-specific properties
        public virtual ICollection<Patient> Patients { get; set; }
    }
