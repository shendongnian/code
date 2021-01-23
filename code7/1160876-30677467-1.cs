    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        public virtual Therapist Therapist { get; set; }
        public virtual Patient Patient { get; set; }
    }
    
    public class Patient
    {
        [Key]
        [ForeignKey("Login")]
        [Display(Name = "No.")]
        public int PatientId { get; set; }
        public virtual Login Login { get; set; }
        // was this supposed to be optional?
        [ForeignKey("Therapist")]
        public int? TherapistId{ get; set; }
        public virtual Therapist Therapist { get; set; }
      }
    public class Therapist
    {
        [Key]
        [ForeignKey("Login")]
        [Display(Name = "No.")]
        public int TherapistId { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
