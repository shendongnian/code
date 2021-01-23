    if (tempUser != null)	
    {
    	SessionUser = new LoginViewModel
    	{
    		ProfileId = tempUser.ProfileId,
    		SessionId = tempUser.SessionId,
    		FullName = Format.FullName(tempUser.Salutation, tempUser.FirstName, tempUser.MiddleName, tempUser.LastName),
    		Email = tempUser.Email
    	};
    }
