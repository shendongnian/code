    public class EditSinglesVM
    {
      [Required(ErrorMessage = "Please select player A")]
      [Display(Name = "Player A")]
      public int APlayerID { get; set; }
      ....
      [Required(ErrorMessage = "Please select a course")]
      [Display(Name = "Course")]
      public int CourseID { get; set; }
      public IEnumerable<SelectListItem> PlayerList { get; set; }
      public IEnumerable<SelectListItem> CourseList { get; set }
    }
