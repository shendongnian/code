    public class LookUpViewModel
    {
      [Display(Name = "Location")]
      [Required(ErrorMessage = "Please select a location")]
      public int SelectedLocation { get; set; }
      [Display(Name = "Stream")]
      [Required(ErrorMessage = "Please select a stream")]
      public int SelectedStream { get; set; }
      public SelectList LocationList { get; set; }
      public SelectList StreamList { get; set; }
    }
