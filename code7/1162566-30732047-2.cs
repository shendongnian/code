    public class UserViewModel
    {
    	[Validator(typeof(UserValidator))]
    	public string UserName { get; set; }
    }
