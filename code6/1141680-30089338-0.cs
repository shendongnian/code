    public class RegisterViewModel
    {
      [Required]
      [Display(ResourceType = typeof(ResourceStrings), Name = "Username")]
      [StringLength(50, ErrorMessageResourceType = typeof(ResourceStrings), ErrorMessageResourceName = "MinLengthValidation", MinimumLength = 4)]
      public string Username { get; set; }
      ....
      // For binding the selected roles
      [Required(ErrorMessage = "Please select a role")]
      public int ID SelectedRole { set; set; }
      // For displaying the available roles 
      [Display(Name = "Roles")]
      public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
