	private readonly IAuthenticateStrategy _authenticateStrategy;
	public AuthenticateController(IAuthenticateStrategy authenticateStrategy)
	{
		if (authenticateStrategy == null)
			throw new ArgumentNullException("authenticateStrategy");
			
		_authenticateStrategy = authenticateStrategy;
	}
	// login with twitter
	public virtual ActionResult Twitter(string user, string pass)
	{
		bool success =
				_authenticateStrategy.Login("TwitterAuth", user, pass);
	}
	// login with fb
	public virtual ActionResult Facebook(string user, string pass)
	{
		bool success =
				_authenticateStrategy.Login("FacebookAuth", user, pass);
	}
