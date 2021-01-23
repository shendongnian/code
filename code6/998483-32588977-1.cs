    public class AddressModel
    {
        public AddressModel()
        {
            AvailableUSStates = new List<SelectListItem>();
            AvailableLibraries = new List<SelectListItem>();
        }
        [Display(Name = "USState")]
        [Required(ErrorMessage = ("Please choose a State"))]
        public int USStateID { get; set; }
        //public string USStateName { get; set; }
        public List<SelectListItem> AvailableUSStates { get; set; }
        [Display(Name = "Library")]
        [Required(ErrorMessage = ("Please chose a Library for the selected State"))]
        public int LibraryID { get; set; }
        public List<SelectListItem> AvailableLibraries { get; set; }
    }
    public class ConfirmModel
    {
        
        [Display(Name = "State Name")]
        public string USStateName { get; set; }
        [Display(Name = "County Name")]
        public string CountyName { get; set; }
    }
