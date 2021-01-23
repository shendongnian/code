    public class Patient : ApplicationUser
    {
        // patient-specific properties
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; } // IdentityUser's PK is string by default
        public virtual Doctor Doctor { get; set; }
    }
    public class Doctor : ApplicationUser
    {
        // doctor-specific properties
        public virtual ICollection<Patient> Patients { get; set; }
    }
