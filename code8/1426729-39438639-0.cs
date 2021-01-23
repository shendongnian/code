	public class ContactInfo
	{
	    [Required(ErrorMessage = "Your email address is invalid")]
	    [Display(Name = "User Email")]
	    public int Email { get; set; }
	    [Required(ErrorMessage = "Your phone number is invalid")]
	    [Display(Name = "User Phone")]
	    public int Phone { get; set; }
	}
