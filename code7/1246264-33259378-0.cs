    public async Task Invoke(HttpContext context, ApplicationDbContext applicationContext, SignInManager<ApplicationUser> signInManager)
    {
    	if (string.IsNullOrEmpty(context.User.Identity.Name))
    	{
    		var result = await signInManager.PasswordSignInAsync(_options.UserName, _options.Password, true, false);
    	}
    
    	await _next(context);
    }
