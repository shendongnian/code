	var user = newsManager.GetUserUsingEmail(User.Email);
	if(user != null && !string.IsNullOrEmpty(user.Email))
	{
		//User Exists and has a valid email
	}
	else
	{
		//User Doesn't exists or doesn't have a valid email.
	}
