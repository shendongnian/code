    public void SignIn(string username, string password)
    {    
    	var login = _userService.TryGetLogin(username);
    	if (login == null){
    		// Login by username not found.
    		// Return error message "Invalid username or password"
    		return;
    	}
        
    	if (login.LoginFailedAttemptsCount > MaxNumberOfFailedAttemptsToLogin
    	&& login.LastLoginAttemptAt.HasValue
    	&& DateTime.Now < login.LastLoginAttemptAt.Value.AddMinutes(BlockMinutesAfterLimitFailedAttemptsToLogin))
    	{
    		// Login is blocked, need to break the process.
    		// Return error message "Your account was blocked 
    		// for a 15 minutes, please try again later."
    		return;
    	} else {
    		login.LoginFailedAttemptsCount = 0;
    		login.LastLoginAttemptAt = DateTime.Now;
        }
        
    	var success = login.ValidatePassword(password);
    	if (!success)
    	{
    		// Invalid password, need to update the number of attempts.
    		login.LastLoginAttemptAt = DateTime.Now; //or UTC
    		login.LoginFailedAttemptsCount++;
    		// Update(login);
    		// Return error message "Invalid username or password"
    		return;
    	} else {
    		login.LoginFailedAttemptsCount = 0;
    		login.LastLoginAttemptAt = DateTime.Now;
    		// Update(login);
    		// Success!
    	}
    }
    
