    public class PlayerFormViewModel
    {
        public PlayerFormEnglish PlayerFormEnglish { get; set; }
        public PlayerFormSpanish PlayerFormSpanish { get; set; }
    }
    
    public class PlayerFormEnglish : PlayerFormInformation { }
    public class PlayerFormSpanish : PlayerFormInformation { }
    public class PlayerFormInformation
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        // Used as a dropdown in the view
        [Display(Name = "Gender")]
        public IEnumerable<SelectListItem> Gender{ get; set; }
    }
