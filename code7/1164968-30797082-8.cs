    public class User
    {
      [Required(ErrorMessage = "Please fill-in Username.")]
      [Display(Name = "Username:")]
      public string UserName { get; set; }
      [Required(ErrorMessage = "Please fill-in Employee ID.")]
      [Display(Name = "ID:")]
      public string ID { get; set; }
    }
