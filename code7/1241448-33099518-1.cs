	private readonly IUserService UserService = null;
	public CustomAccessAttribute(IUserService userService)
	{
		this.UserService = userService;
	}
	
	public CustomAccessAttribute(IUserService userService, bool someParam) : this(userService) 
	{         
	}
	
