	private readonly IUserService UserService = null;
	public CustomAccessAttribute(IUserService userService) : this(userService, false)
	{
	}
	
	public CustomAccessAttribute(IUserService userService, bool someParam)
	{  
		this.UserService = userService;
	}
	
