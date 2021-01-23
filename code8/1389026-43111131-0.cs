	[HttpPost]
	public async Task<ActionResult> Login(LoginViewModel viewModel, string returnUrl)
	{
		// incremental delay to prevent brute force attacks
		int incrementalDelay;
		if (HttpContext.Application[Request.UserHostAddress] != null)
		{
			// wait for delay if there is one
			incrementalDelay = (int)HttpContext.Application[Request.UserHostAddress];
			await Task.Delay(incrementalDelay * 1000);
		}
	 
		if (!ModelState.IsValid)
			return View();
	 
		// authenticate user
		var user = _userService.Authenticate(viewModel.Username, viewModel.Password);
	 
		if (user == null)
		{
			// login failed
	 
			// increment the delay on failed login attempts
			if (HttpContext.Application[Request.UserHostAddress] == null)
			{
				incrementalDelay = 1;
			}
			else
			{
				incrementalDelay = (int)HttpContext.Application[Request.UserHostAddress] * 2;
			}
			HttpContext.Application[Request.UserHostAddress] = incrementalDelay;
	 
			// return view with error
			ModelState.AddModelError("", "The user name or password provided is incorrect.");
			return View();
		}
	 
		// login success
	 
		// reset incremental delay on successful login
		if (HttpContext.Application[Request.UserHostAddress] != null)
		{
			HttpContext.Application.Remove(Request.UserHostAddress);
		}
	 
		// set authentication cookie
		_formsAuthenticationService.SetAuthCookie(
			user.Username,
			viewModel.KeepMeLoggedIn,
			null);
	 
		// redirect to returnUrl
		return Redirect(returnUrl);
	}
