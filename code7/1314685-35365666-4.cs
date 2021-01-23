	public static async Task<string> ProcessErrorAsync(
				Exception ex, string OriginatingController)
	{
		var Component = GetComponent(OriginatingController);
		string UserErrorMessage = "";
	
		switch (ex.GetType().ToString())
		{
			case "System.Data.DataException":
				LogToITSupport("Database Connection");
				UserErrorMessage = @"An error has accrued connecting to the 
				database. <a href=""mailto:"">IT Support</a> has been notified
				of this error. Please try your request again later, thank you.";
				break;
	
			default:
				var bugId = await LogToBugZillaAsync(Component, ex);
				UserErrorMessage = @"An error has accrued processing your request 
				and a log of this error has been made 
				on the <a href=""http://bugzilla/show_bug.cgi?id=" + BugID +
				"\">Internal Tools BugZilla system</a> 
				with an ID of " + bugId + ". Please try your request again later, thank you.";
				break;
		}
		return UserErrorMessage;
	}
	
