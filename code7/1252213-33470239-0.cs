    public class RegisterViewModel
    {
      [Display(Name = "Assigned Teams")]
      [Required(ErrorMessage = "Please select a team")]
      public string SelectedTeam { get; set; }
      public SelectList TeamsList { get; set; }
      ....
    }
