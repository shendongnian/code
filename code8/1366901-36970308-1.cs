    public class Doctor
    {
        public int DoctorId { set; get; }
        [Required]
        [Display(Name = "Name")]
        [UniqueDoctorName(nameof(DoctorId))]
        public string DoctorName { get; set; }
    }
