    public class RegisterViewModel
    {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }
    [Required]
    [Display(Name = "Role")]
    public string Name { get; set; }
    //store roles
    public IEnumerable<Role> Roles {get;set;}
    }
