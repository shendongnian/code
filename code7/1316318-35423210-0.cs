    public class PersonVM
        [Required(ErrorMessage = "Please select a Gender")]
        public string Gender { get; set; } // or use an enum
        public IEnumerable<SelectListItem> GenderList { get; set; }
    }
