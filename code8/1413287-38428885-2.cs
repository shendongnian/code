    public class PatientAdmissionViewModel
    {
        [Display(Name = "Ward"]
        [Required(ErrorMessage = "Please select a ward")]
        public int? SelectedWard { get; set; }
        [Display(Name = "Doctor"]
        [Required(ErrorMessage = "Please select a doctor")]
        public IEnumerable<SelectListItem> WardList { get; set; }
        public int? SelectedDoctor { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        public string PatientName { get; set; }
        ... // other properties of Patient that you need in the view
        public string AdmissionNumber{ get; set; }
        ... // other properties of Admission that you need in the view
    }
