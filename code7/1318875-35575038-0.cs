	public class User
	{
      [Required(ErrorMessage = "Please enter a name")]
      [Display(Name = "Persons Name")]
      public string Name { get; set; }
      public string Email { get; set; }
      public string Description { get; set; }
	}
