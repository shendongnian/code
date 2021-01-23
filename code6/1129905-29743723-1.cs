    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMEssage = "Email is required")]
        public string PersonalEmail { get; set; }
    }
