    public class Chart 
    {
        [Key]
        public int Id { get; set; } 
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
