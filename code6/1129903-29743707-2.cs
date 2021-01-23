    public class Student
    {
      [Required(ErrorMessage = "Name is required")]
      public String Firstname { get; set; }
      [Required(ErrorMessage = "Email is required")]
      public String personalEmail { get; set; }
    }
